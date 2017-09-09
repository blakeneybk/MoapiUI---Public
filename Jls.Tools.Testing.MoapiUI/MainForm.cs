using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms.ToolTips;
using Jls.Tools.Testing.MoapiClient.Configuration;
using Jls.Tools.Testing.MoapiClient.Geography;
using Jls.Tools.Testing.MoapiClient.Models;
using Jls.Tools.Testing.MoapiUI.Configuration;
using Telerik.WinControls.Data;
using Telerik.WinControls.UI;
using System.Diagnostics;
// ReSharper disable All

namespace Jls.Tools.Testing.MoapiUI
{
    public partial class MainForm : Form
    {
        private readonly GMapControl _mapControlA = new GMapControl();
        private GMapOverlay _listingsOverlayA = new GMapOverlay("listings_A");

        private GMapControl _mapControlB = new GMapControl();
        private GMapOverlay _listingsOverlayB = new GMapOverlay("listings_B");
        private IMapSource _mapSourceA;
        private IMapSource _mapSourceB;
        private readonly AppConfigSettings _settings = new AppConfigSettings();
        private SearchRequest _request = new SearchRequest();
        private ValueConverter _converter = new ValueConverter();
        private bool _isMouseDown;
        private bool _mapPositionAUpdated;
        private bool _mapPositionBUpdated;
        private bool _ignoreEvent;

        public MainForm()
        {
            InitializeComponent();

            //Trackbar Range Change Events
            #region Range CollectionChanged Events
            tbPrice.Ranges.CollectionChanged += RangesOnCollectionChanged;
            tbBeds.Ranges.CollectionChanged += RangesOnCollectionChanged;
            tbBaths.Ranges.CollectionChanged += RangesOnCollectionChanged;
            tbAcres.Ranges.CollectionChanged += RangesOnCollectionChanged;
            tbGarages.Ranges.CollectionChanged += RangesOnCollectionChanged;
            tbSqFt.Ranges.CollectionChanged += RangesOnCollectionChanged;
            tbYear.Ranges.CollectionChanged += RangesOnCollectionChanged;
            tbTOM.Ranges.CollectionChanged += RangesOnCollectionChanged;
            #endregion
            //------------------------------------------------------------------------------------------------------------------------------------------
            #region MapControl Properties and Setup
            this._mapControlA.Bearing = 0F;
            this._mapControlA.CanDragMap = true;
            this._mapControlA.Dock = System.Windows.Forms.DockStyle.Fill;
            this._mapControlA.EmptyTileColor = System.Drawing.Color.Navy;
            this._mapControlA.GrayScaleMode = false;
            this._mapControlA.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this._mapControlA.LevelsKeepInMemmory = 5;
            this._mapControlA.Location = new System.Drawing.Point(0, 0);
            this._mapControlA.MarkersEnabled = true;
            this._mapControlA.MaxZoom = 17;
            this._mapControlA.MinZoom = 2;
            this._mapControlA.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this._mapControlA.Name = "_mapControl";
            this._mapControlA.NegativeMode = false;
            this._mapControlA.PolygonsEnabled = true;
            this._mapControlA.RetryLoadTile = 0;
            this._mapControlA.RoutesEnabled = true;
            this._mapControlA.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this._mapControlA.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this._mapControlA.ShowTileGridLines = false;
            this._mapControlA.Size = new System.Drawing.Size(661, 665);
            this._mapControlA.TabIndex = 0;
            this._mapControlA.Zoom = 0D;
            this._mapControlA.MouseUp += MapControl_OnMouseUp;
            this._mapControlA.OnMapZoomChanged += MapControlA_MapZoomChanged;
            this._mapControlA.OnPositionChanged += MapControlA_PositionChanged;

            _mapControlA.MapProvider = GMapProviders.GoogleMap;
            _mapControlA.Position = new PointLatLng(48.037071, -121.927404);
            _mapControlA.DragButton = MouseButtons.Left;
            _mapControlA.MinZoom = 0;
            _mapControlA.MaxZoom = 24;
            _mapControlA.Zoom = 9;

            this._mapControlB.Bearing = 0F;
            this._mapControlB.CanDragMap = true;
            this._mapControlB.Dock = System.Windows.Forms.DockStyle.Fill;
            this._mapControlB.EmptyTileColor = System.Drawing.Color.Navy;
            this._mapControlB.GrayScaleMode = false;
            this._mapControlB.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this._mapControlB.LevelsKeepInMemmory = 5;
            this._mapControlB.Location = new System.Drawing.Point(0, 0);
            this._mapControlB.MarkersEnabled = true;
            this._mapControlB.MaxZoom = 17;
            this._mapControlB.MinZoom = 2;
            this._mapControlB.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this._mapControlB.Name = "_mapControl";
            this._mapControlB.NegativeMode = false;
            this._mapControlB.PolygonsEnabled = true;
            this._mapControlB.RetryLoadTile = 0;
            this._mapControlB.RoutesEnabled = true;
            this._mapControlB.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this._mapControlB.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this._mapControlB.ShowTileGridLines = false;
            this._mapControlB.Size = new System.Drawing.Size(661, 665);
            this._mapControlB.TabIndex = 0;
            this._mapControlB.Zoom = 0D;            

            _mapControlB.MapProvider = GMapProviders.GoogleMap;
            _mapControlB.Position = new PointLatLng(48.037071, -121.927404);
            _mapControlB.DragButton = MouseButtons.Left;
            _mapControlB.MinZoom = 0;
            _mapControlB.MaxZoom = 24;
            _mapControlB.Zoom = 9;
            _mapControlB.OnPositionChanged += MapControlBOnOnPositionChanged;
            _mapControlB.OnMapZoomChanged += MapControlBOnOnMapZoomChanged;            
            _mapControlB.MouseUp += MapControl_OnMouseUp;
            _mapControlB.MouseDown += MapControl_OnMouseDown;
            _mapControlB.MouseMove += MapControl_OnMouseMove;



       

            this.mapSplitter.Panel1.Controls.Add(this._mapControlA);
            this.mapSplitter.Panel2.Controls.Add(this._mapControlB);

            // Setup our map sources
            _mapSourceA = new ApiMapSource(new Uri(_settings.MapSourceA), _settings);
            _mapSourceB = new ApiMapSource(new Uri(_settings.MapSourceB), _settings);

            _mapControlA.Tag = _mapSourceA;
            _mapControlB.Tag = _mapSourceB;

            // Initialize them be establishing the necessary session contexts
            _mapSourceA.Initialize();
            _mapSourceB.Initialize();

            // Add the listing overlays
            _mapControlA.Overlays.Add(_listingsOverlayA);
            _mapControlB.Overlays.Add(_listingsOverlayB);

            #endregion
            //------------------------------------------------------------------------------------------------------------------------------------------
            //------------------------------------------------------------------------------------------------------------------------------------------
            #region Control Tagging
            tbPrice.Tag = CriteriaType.Price;
            tbPrice.TrackBarElement.Tag = tbPrice.Tag;
            tbBeds.Tag = CriteriaType.Beds;
            tbBeds.TrackBarElement.Tag = tbBeds.Tag;
            tbBaths.Tag = CriteriaType.Baths;
            tbBaths.TrackBarElement.Tag = tbBaths.Tag;
            tbSqFt.Tag = CriteriaType.SqFt;
            tbSqFt.TrackBarElement.Tag = tbSqFt.Tag;
            tbAcres.Tag = CriteriaType.Acres;
            tbAcres.TrackBarElement.Tag = tbAcres.Tag;
            tbYear.Tag = CriteriaType.Year;
            tbYear.TrackBarElement.Tag = tbYear.Tag;
            tbGarages.Tag = CriteriaType.Garages;
            tbGarages.TrackBarElement.Tag = tbGarages.Tag;
            tbTOM.Tag = CriteriaType.TOM;
            tbTOM.TrackBarElement.Tag = tbTOM.Tag;
            listingStatusCheckedListBox.CheckedDropDownListElement.Tag = CriteriaType.ListingStatus;
            propertyTypeCheckedListBox.CheckedDropDownListElement.Tag = CriteriaType.PropertyType;
            searchOptionsCheckedListBox.CheckedDropDownListElement.Tag = CriteriaType.SearchOptions;
            #endregion
            //------------------------------------------------------------------------------------------------------------------------------------------
            //Debug.WriteLine("Initialize - Year Max:{0}Year Min:{1}",tbYear.Maximum,tbYear.Minimum);
            tbYear.Maximum = DateTime.Now.Year;
            tbYear.Minimum = 1800;
            //Debug.WriteLine("Fixed? Year Max:{0}Year Min:{1}",tbYear.Maximum,tbYear.Minimum);

            //foreach (var item in listingStatusCheckedListBox.CheckedItems)
            //{

            //    Debug.WriteLine("Name:{0} Tag:{1} IsChecked:{2}",item.Text,item.Tag,item.Checked);
            //}
            //foreach (var item in listingStatusCheckedListBox.Items)
            //{

            //    Debug.WriteLine("Name:{0} Tag:{1}",item.Text,item.Tag);
            //}
        }
        
        #region MapControl Events
        private void MapControlA_PositionChanged(PointLatLng point)
        {
            
            _mapPositionBUpdated = true;
            if (_mapPositionAUpdated != _mapPositionBUpdated)
            {
                _mapControlB.Position = point;
                _mapControlA.Refresh();
                
            }
            _mapPositionBUpdated = false;
        }

        private void MapControlBOnOnPositionChanged(PointLatLng point)
        {
            
            _mapPositionAUpdated = true;
            if (_mapPositionAUpdated != _mapPositionBUpdated)
            {
                _mapControlA.Position = point;
                _mapControlB.Refresh();
                
            }
            _mapPositionAUpdated = false;
        }

        private void MapControlA_MapZoomChanged()
        {            
            _mapControlB.Zoom = _mapControlA.Zoom;
            _mapControlB.Position = _mapControlA.Position;

            
        }

        private void MapControl_OnMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && _isMouseDown)
            {
                
            }
        }

        private void MapControl_OnMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                _isMouseDown = true;
        }

        private void MapControl_OnMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                _isMouseDown = false;


            DoSearch(_mapControlA);
            DoSearch(_mapControlB);
        }
       
        private void MapControlBOnOnMapZoomChanged()
        {
            _mapControlA.Zoom = _mapControlB.Zoom;
            _mapControlA.Position = _mapControlB.Position;



            DoSearch(_mapControlA);
            DoSearch(_mapControlB);
        }
        #endregion
        
        private void DoSearch(GMapControl control)
        {
            
            //Set search area bounds
            _request.Area =
                new GeoRectangle((float) control.ViewArea.Right, (float) control.ViewArea.Bottom,
                    (float) control.ViewArea.Left, (float) control.ViewArea.Top);
            
            // Execute Search...
            var response = ((IMapSource)control.Tag).Search(_request);            

            control.Overlays[0].Markers.Clear();

            foreach (var listing in response.Listings)
            {
                var markerIco = listing.Status == ListingStatus.Pending
                    ? GMarkerGoogleType.brown_small
                    : GMarkerGoogleType.blue_small;

                if (listing.Status == ListingStatus.Sold)
                    markerIco = GMarkerGoogleType.red_small;

                if (listing.ListDate.HasValue && listing.ListDate.Value > DateTime.UtcNow.AddDays(-7))
                    markerIco = GMarkerGoogleType.green_small;

                var marker = new GMarkerGoogle(
                           new PointLatLng(listing.Location.Latitude,
                               listing.Location.Longitude), markerIco);

                marker.ToolTip = new GMapBaloonToolTip(marker);

                marker.ToolTipText =
                          $"{listing.MlsListingId} - {listing.Address.Street}, {listing.Address.City} ${listing.ListPrice}";

                control.Overlays[0].Markers.Add(marker);

            }
        }    

          
        
        //------------------------------------------------------------------------------------------------------------------------------------------
        #region Search Request Updates
        //Trackbar Mouse Up performs search
        private void trackBar_MouseUp(object sender, MouseEventArgs e)
        {
            DoSearch(_mapControlA);
            DoSearch(_mapControlB);
        }
        //Trackbar Scrolling Behavior

        private void RangesOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs)
        {
            if (_ignoreEvent)
                return;
            var newSender = ((TrackBarRangeCollection) sender).Owner;
            int min = (int)newSender.Ranges[0].Start;
            int max = (int) newSender.Ranges[0].End;

            switch ((CriteriaType)newSender.Tag)
            {
                case CriteriaType.Price:
                    priceMinLabel.Text = (_request.Price.Min = _converter.ConvertProgressToPrice(min)).ToString();
                    if(min == tbPrice.Minimum)
                        priceMinLabel.Text = "(No Min)";
                    if (max < tbPrice.Maximum)
                        priceMaxLabel.Text = (_request.Price.Max = _converter.ConvertProgressToPrice(max)).ToString();
                    else
                    {
                        _request.Price.Max = Int32.MaxValue;
                        priceMaxLabel.Text = "(No Max)";
                    }
                    break;
                case CriteriaType.Acres:
                    acresMinLabel.Text = (_request.Acres.Min = _converter.ConvertProgressToAcres(min)).ToString();                    
                    if(min == tbAcres.Minimum)
                        acresMinLabel.Text = "(No Min)";
                    if (max < tbAcres.Maximum)
                        acresMaxLabel.Text = (_request.Acres.Max = _converter.ConvertProgressToAcres(max)).ToString();
                    else
                    {
                        _request.Acres.Max = Int32.MaxValue;
                        acresMaxLabel.Text = "(No Max)";
                    }
                    break;
                case CriteriaType.Beds:
                    bedsMinLabel.Text = (_request.Beds.Min = min).ToString();                  
                    if(min == tbBeds.Minimum)
                        bedsMinLabel.Text = "(No Min)";
                    if (max < tbBeds.Maximum)
                        bedsMaxLabel.Text = (_request.Beds.Max = max).ToString();
                    else
                    {
                        _request.Beds.Max = Int32.MaxValue;
                        bedsMaxLabel.Text = "(No Max)";
                    }
                    break;
                case CriteriaType.Baths:
                    bathsMinLabel.Text = (_request.Baths.Min = _converter.ConvertProgressToBaths(min)).ToString();
                    if(min == tbBaths.Minimum)
                        bathsMinLabel.Text = "(No Min)";
                    if (max < tbBaths.Maximum)
                        bathsMaxLabel.Text = (_request.Baths.Max = _converter.ConvertProgressToBaths(max)).ToString();
                    else
                    {
                        _request.Baths.Max = Int32.MaxValue;
                        bathsMaxLabel.Text = "(No Max)";
                    }
                    break;
                case CriteriaType.Garages:
                    garagesMinLabel.Text = (_request.Garages.Min = min).ToString();
                    if(min == tbGarages.Minimum)
                        garagesMinLabel.Text = "(No Min)";
                    if (max < tbGarages.Maximum)
                        garagesMaxLabel.Text = (_request.Garages.Max = max).ToString();
                    else
                    {
                        _request.Garages.Max = Int32.MaxValue;
                        garagesMaxLabel.Text = "(No Max)";
                    }
                    break;
                case CriteriaType.Year:
                    yearMinLabel.Text = (_request.Year.Min = min).ToString();
                    yearMaxLabel.Text = (_request.Year.Max = max).ToString();
                    break;
                case CriteriaType.SqFt:
                    sqftMinLabel.Text = (_request.SqFt.Min = _converter.ConvertProgressToSqFt(min)).ToString();
                    if(min == tbSqFt.Minimum)
                        acresMinLabel.Text = "(No Min)";
                    if (max < tbSqFt.Maximum)
                        sqftMaxLabel.Text = (_request.SqFt.Max = _converter.ConvertProgressToSqFt(max)).ToString();
                    else
                    {
                        _request.SqFt.Max = Int32.MaxValue;
                        sqftMaxLabel.Text = "(No Max)";
                    }
                    break;
                case CriteriaType.TOM:
                    tomLabel.Text = (_request.CDOM = (int)newSender.Value) + " Days";
                    if (newSender.Value == tbTOM.Maximum)
                    {
                        _request.CDOM = Int32.MaxValue;
                        tomLabel.Text = "(No Max)";
                    }

                    break;
            }
/*        Debug.WriteLine("_request -- Price:[{0},{1}] Beds:[{2},{3}] Baths:[{4},{5}] SqFt:[{6},{7}] Acres:[{8},{9}] Year:[{10},{11}] Garages:[{12},{13}] TOM:{14}",
                        _request.Price.Min,_request.Price.Max,_request.Beds.Min,_request.Beds.Max,_request.Baths.Min,_request.Baths.Max,
                        _request.SqFt.Min,_request.SqFt.Max,_request.Acres.Min,_request.Acres.Max,_request.Year.Min,_request.Year.Max,
                        _request.Garages.Min,_request.Garages.Max,_request.TimeOnMarket);*/
        }

        //Max Results
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (_ignoreEvent)
                return;
            var newSender = (NumericUpDown) sender;
            _request.MaxResults = (int)newSender.Value;
            DoSearch(_mapControlA);
            DoSearch(_mapControlB);
        }
        
        //Checkbox Handlers
        private void ItemCheckedChanged(object sender, RadCheckedListDataItemEventArgs e)
        {
            if (_ignoreEvent)
                return; 
            var newSender = (RadCheckedDropDownListElement) sender;
            switch ((CriteriaType) newSender.Tag)
            {
                case CriteriaType.ListingStatus:
                    _request.StatusTypes.Clear();
                    foreach (var item in newSender.CheckedItems)
                    {
                        _request.StatusTypes.Add(int.Parse(item.Tag.ToString()));
                    }
                break;
                case CriteriaType.PropertyType:
                    _request.PropertyTypes.Clear();
                    foreach (var item in newSender.CheckedItems) 
                    {
                        _request.PropertyTypes.Add(int.Parse(item.Tag.ToString()));
                    }
                break;
                case CriteriaType.SearchOptions:
                    _request.SearchOptionTypes.Clear();
                    foreach (var item in newSender.CheckedItems)  
                    {
                        _request.SearchOptionTypes.Add(int.Parse(item.Tag.ToString()));
                    }
                    break;
            }

            //DEBUG CODE
            //Debug.WriteLine("_request -- Status List:[{0}] Property List:[{1}] Search Option List: [{2}]", 
            //    string.Join(",", _request.StatusTypes), string.Join(",", _request.PropertyTypes), string.Join(",", _request.SearchOptionTypes));

            DoSearch(_mapControlA);
            DoSearch(_mapControlB);
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            ResetSearchRequest();
            UpdateCriteriaUI(_request);
            DoSearch(_mapControlA);
            DoSearch(_mapControlB);
        }
        #endregion
        //------------------------------------------------------------------------------------------------------------------------------------------
        
            
            
        private void miSettings_Click(object sender, EventArgs e)
        {
            var settingsForm = new SettingsForm();
            settingsForm.ShowDialog(this);
        }
        
        private void ResetSearchRequest()
        {
            _request = new SearchRequest();
            
        }

        private void UpdateCriteriaUI(ISearchRequest criteria)
        {
            //prevent event handler processing
            _ignoreEvent = true;
            
            // Update the UI trackbars
            //Special conversions
            tbPrice.Ranges[0].Start = _converter.ConvertPriceToProgress(criteria.Price.Min, (int) tbPrice.Maximum);
            tbPrice.Ranges[0].End =_converter.ConvertPriceToProgress(criteria.Price.Max, (int) tbPrice.Maximum);
            tbAcres.Ranges[0].Start =_converter.ConvertAcresToProgress(criteria.Acres.Min, (int) tbAcres.Maximum);
            tbAcres.Ranges[0].End =_converter.ConvertAcresToProgress(criteria.Acres.Max, (int) tbAcres.Maximum);
            tbSqFt.Ranges[0].Start =_converter.ConvertSqFtToProgress(criteria.SqFt.Min, (int) tbSqFt.Maximum);
            tbSqFt.Ranges[0].End =_converter.ConvertSqFtToProgress(criteria.SqFt.Max, (int) tbSqFt.Maximum);
            tbBaths.Ranges[0].Start =_converter.ConvertBathsToProgress(criteria.Baths.Min, (int) tbBaths.Maximum);
            tbBaths.Ranges[0].End =_converter.ConvertBathsToProgress(criteria.Baths.Max,(int) tbBaths.Maximum);
            //Generic conversions
            tbBeds.Ranges[0].Start =_converter.ConvertRealValueToUiValue(criteria.Beds.Min, (int) tbBeds.Minimum, (int) tbBeds.Maximum);
            tbBeds.Ranges[0].End =_converter.ConvertRealValueToUiValue(criteria.Beds.Max, (int) tbBeds.Minimum, (int) tbBeds.Maximum);
            tbYear.Ranges[0].Start =_converter.ConvertRealValueToUiValue(criteria.Year.Min, (int) tbYear.Minimum, (int) tbYear.Maximum);
            tbYear.Ranges[0].End =_converter.ConvertRealValueToUiValue(criteria.Year.Max, (int) tbYear.Minimum, (int) tbYear.Maximum);
            tbGarages.Ranges[0].Start =_converter.ConvertRealValueToUiValue(criteria.Garages.Min, (int) tbGarages.Minimum,(int) tbGarages.Maximum);
            tbGarages.Ranges[0].End =_converter.ConvertRealValueToUiValue(criteria.Garages.Max, (int) tbGarages.Minimum,(int) tbGarages.Maximum);
            tbTOM.Value = _converter.ConvertRealValueToUiValue(criteria.CDOM, (int)tbTOM.Minimum, (int)tbTOM.Maximum);

            //Update the UI dropdowns
            PopulateCheckedListBox(listingStatusCheckedListBox,criteria.StatusTypes);
            PopulateCheckedListBox(propertyTypeCheckedListBox,criteria.PropertyTypes);
            PopulateCheckedListBox(searchOptionsCheckedListBox,criteria.SearchOptionTypes);

            numericUpDown1.Value = _converter.ConvertRealValueToUiValue(criteria.MaxResults, (int)numericUpDown1.Minimum,(int)numericUpDown1.Maximum);

            //Resume normal event handler function
            UpdateLabels(criteria);
            _ignoreEvent = false;
        }
        private void UpdateLabels(ISearchRequest criteria)
        {    
            priceMinLabel.Text = criteria.Price.Min.ToString();
            priceMaxLabel.Text = criteria.Price.Max.ToString();
            if(criteria.Price.Min == tbPrice.Minimum)
                priceMinLabel.Text = "(No Min)";
            if (_converter.ConvertPriceToProgress(criteria.Price.Max, (int)tbPrice.Maximum) == tbPrice.Maximum)
                priceMaxLabel.Text = "(No Max)";

            acresMinLabel.Text = criteria.Acres.Min.ToString();
            acresMaxLabel.Text = criteria.Acres.Max.ToString();
            if(criteria.Acres.Min == (decimal)tbAcres.Minimum)
                acresMinLabel.Text = "(No Min)";
            if (_converter.ConvertAcresToProgress(criteria.Acres.Max,(int)tbAcres.Maximum) == (decimal)tbAcres.Maximum)
                acresMaxLabel.Text = "(No Max)";

            bedsMinLabel.Text = criteria.Beds.Min.ToString();
            bedsMaxLabel.Text = criteria.Beds.Max.ToString();
            if(criteria.Beds.Min == tbBeds.Minimum)
                bedsMinLabel.Text = "(No Min)";
            if (criteria.Beds.Max > tbBeds.Maximum)
                bedsMaxLabel.Text = "(No Max)";
    
            bathsMinLabel.Text = criteria.Baths.Min.ToString();
            bathsMaxLabel.Text = criteria.Baths.Max.ToString();
            if(criteria.Baths.Min == (decimal)tbBaths.Minimum)
                bathsMinLabel.Text = "(No Min)";
            if (_converter.ConvertBathsToProgress(criteria.Baths.Max,(int)tbBaths.Maximum) == (decimal)tbBaths.Maximum)
                bathsMaxLabel.Text = "(No Max)";
                    
            garagesMinLabel.Text = criteria.Garages.Min.ToString();
            garagesMaxLabel.Text = criteria.Garages.Max.ToString();
            if(criteria.Garages.Min == tbGarages.Minimum)
                garagesMinLabel.Text = "(No Min)";
            if (criteria.Garages.Max > tbGarages.Maximum)
                garagesMaxLabel.Text = "(No Max)";

            sqftMinLabel.Text = criteria.SqFt.Min.ToString();
            sqftMaxLabel.Text = criteria.SqFt.Max.ToString();
            if(criteria.SqFt.Min == tbSqFt.Minimum)
                sqftMinLabel.Text = "(No Min)";
            if (_converter.ConvertSqFtToProgress(criteria.SqFt.Max,(int)tbSqFt.Maximum) == tbSqFt.Maximum)
                sqftMaxLabel.Text = "(No Max)";

            yearMinLabel.Text = criteria.Year.Min.ToString();
            yearMaxLabel.Text = criteria.Year.Max.ToString();

            tomLabel.Text = criteria.CDOM + " Days";
            if (criteria.CDOM >= tbTOM.Maximum)
                tomLabel.Text = "(No Max)";
        }

        private void PopulateCheckedListBox(RadCheckedDropDownList cddl, List<int> list)
        {
            cddl.CheckedItems.Clear();
            
            if (list.Count == 0)
                return;
            foreach (var value in list)
            {
                RadCheckedListDataItem item = cddl.Items.FirstOrDefault(x => Convert.ToInt32(x.Tag) == value) as RadCheckedListDataItem;
                item.Checked = true;
            }
        }
    }
}
