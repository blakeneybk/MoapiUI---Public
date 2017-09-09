using System;
using System.Linq;
using System.Text;

namespace Jls.Tools.Testing.MoapiClient.Models
{    
    public class PhoneNumber : IFormattable
    {
        private const string _AlphaMask = "22233344455566677778889999";
        private short _countryCode = 1;
        private short _areaCode;
        private int _localNumber;
        private short _extension;
        private ContactType _contactType;

        #region Properties        
        public short CountryCode
        {
            get { return _countryCode; }
        }

        
        public short AreaCode
        {
            get { return _areaCode; }
            set { _areaCode = value; }
        }

        
        public int LocalNumber
        {
            get { return _localNumber; }
            set { _localNumber = value; }
        }

        
        public short Extension
        {
            get { return _extension; }
            set { _extension = value; }
        }

        
        public ContactType ContactType
        {
            get { return _contactType; }
            set { _contactType = value; }
        }
        #endregion

        #region Methods

        /// <summary>
        /// Parses a literal phone number string and builds a phone number entity.
        /// </summary>
        /// <param name="number">literal telephone number as a string</param>
        /// <returns>Returns a PhoneNumber entity representing the phone number</returns>
        public static PhoneNumber Parse(string number)
        {
            return Parse(number, ContactType.Unknown);
        }

        /// <summary>
        /// Parses a literal phone number string and builds a phone number entity.
        /// </summary>
        /// <param name="number">literal telephone number as a string</param>
        /// <param name="type">Type of this phone number</param>
        /// <returns>Returns a PhoneNumber entity representing the phone number</returns>
        public static PhoneNumber Parse(string number, ContactType type)
        {
            PhoneNumber pn = new PhoneNumber();
            string n = number.Trim().ToLower();

            if (n.Length > 14) {
                // Remove heading literial characters.
                int e = n.Length;
                int r = 0;
                int z = 0;
                while (r < e) {
                    if (((n[r] > 0x40 && n[r] < 0x5B) || n[r] > 0x60 && n[r] < 0x7B) && 
                        (n[r] != '+' && n[r] != '(') || n[r] == 0x20) {
                            r++;
                    }
                    else break;                    
                }

                if (r != e && r != 0) n = n.Remove(0, r);

            }

            // Lame cleanup to remove and trim all the crap that are
            // found in the database for existing customers.  
            n = n.Replace("fax", "");
            n = n.Replace("ext.", "x");

            // This is to remove trailing string characters, i.e. ###-#### mitch
            if (n.Length > 13) {
                int e = n.Length;
                int r = 12;
                int z = 0;
                while (r < e) {
                    if ((n[r] > 0x40 && n[r] < 0x5B) || n[r] > 0x60 && n[r] < 0x7B) {
                        if (z == 0) z = r;
                        else break;
                    }
                    r++;
                }
                if (r != e && z != 0) n = n.Remove(z).TrimEnd();
            }

            char[] nchars = new char[n.Length];
            int c = 0;

            // Convert the literal string to just a basic digit number
            // minus the spaces, '-','()', etc.
            for (int i = 0; i < n.Length; i++) {
                if ((n[i] > 0x2F && n[i] < 0x3A) || n[i] == 0x78) {
                    nchars[c] = n[i];
                    c++;
                }
                else if ((n[i] > 0x40 && n[i] < 0x5B) || n[i] > 0x60 && n[i] < 0x7B) {
                    nchars[c] = _AlphaToDigit(n[i]);
                    c++;
                }
            }

            // Now lets create our base intermediate string
            string ipn = new string(nchars, 0, c);

            try {
                int x = c;
                if (c > 12 && ipn.Contains('x')) {
                    x = ipn.IndexOf('x');
                    if (c - (x+1) < 6)
                        pn.Extension = short.Parse(ipn.Substring((x+1), c - (x+1)));                    
                }

                if (x > 6) {
                    pn.LocalNumber = Int32.Parse(ipn.Substring(x - 7, 7));
                    //x -= 7;
                }

                if (x > 9)
                    pn.AreaCode = short.Parse(ipn.Substring(x - 10, 3));                
            }
            catch (Exception ex) {
                throw new FormatException("Invalid phone number literal.  Can't parse : " + number, ex);
            }


            pn.ContactType = type;
            return pn;
        }

        private static char _AlphaToDigit(char code)
        {
            int x = 0;
            if (code > 0x60 && code < 0x7B) x = code - 0x60;           
            else x = code - 0x40;
            
            if (x > _AlphaMask.Length || x < 0)
                throw new FormatException("Can't convert the alpha code {" + code + "} to a tele-numerical digit.");

            return _AlphaMask[(x-1)];               
        }

        #endregion

        #region IFormattable Members

        public override string ToString()
        {
            return ToString("(a) L:-");
        }

        public string ToString(string format)
        {
            return ToString(format, null);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            // The length of the format is usually a good guess of the number
            // of chars in the result buffer.  Might save us a few cycles.
            StringBuilder result = new StringBuilder(format.Length + 10);

            int i = 0;
            while (i < format.Length) {
                char ch = format[i];

                switch (ch) {
                    //
                    // Phone Formats 
                    //
                    case 'a':   // Area Code
                        result.Append(this._areaCode.ToString());
                        break;

                    case 'L':   // Local Number
                        // Default with the dashed style e.g. 555-5555
                        char seperator = '-'; 

                        // Get the next options (seperator) for the 
                        // local number field.
                        if (format.Length > (i + 2)) {
                            if (format[(i + 1)] == ':') {
                                seperator = format[(i + 2)];
                                i += 2;
                            }
                        }

                        string n = this._localNumber.ToString();
                        result.Append(n.Substring(0, 3));
                        result.Append(seperator);
                        result.Append(n.Substring(3, 4));

                        break;

                    case 'c':   // Country Code
                        result.Append(this._countryCode.ToString());
                        break;

                    case 'X':   // Extension
                        result.Append(this._extension.ToString());
                        break;

                    case '\\':  // C-Style escape
                        if (i >= format.Length -1)
                            throw new FormatException("\\ at end of format string");

                        result.Append(format[i+1]);
                        break;

                    default:
                        // catch all
                        result.Append(ch);
                        break;
                }

                i++;
            }


            return result.ToString();
        } 

        #endregion
    }

    public enum ContactType
    {
        Unknown = 0,
        HomeNumber,
        MobileNumber,
        OfficeNumber,
        PagerNumber,
        FaxNumber
    }

}
