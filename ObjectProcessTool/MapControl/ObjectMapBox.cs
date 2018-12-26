using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.Logging;
using GeoAPI.Geometries;
using System.Diagnostics;
using SharpMap;
using SharpMap.Layers;
using System.Drawing.Imaging;
using System.Threading;
using ObjectProcessTool.Properties;

namespace ObjectProcessTool.MapControl
{

    /// <summary>
    /// MapBox Class - MapBox control for Windows forms
    /// </summary>
    [DesignTimeVisible(true)]
    public class ObjectMapBox : Control
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(ObjectMapBox));

        #region PreviewModes enumerator

        // ReSharper disable UnusedMember.Local
        /// <summary>
        /// Preview modes
        /// </summary>
        public enum PreviewModes
        {
            /// <summary>
            /// Best preview mode
            /// </summary>
            Best,

            /// <summary>
            /// Fast preview mode
            /// </summary>
            Fast
        }

        #endregion

        #region Position enumerators

        /// <summary>
        /// Horizontal alignment enumeration
        /// </summary>
        private enum XPosition
        {
            Center = 0,
            Right = 1,
            Left = -1
        }

        /// <summary>
        /// Vertical alignment enumeration
        /// </summary>
        private enum YPosition
        {
            Center = 0,
            Top = -1,
            Bottom = 1
        }

        // ReSharper restore UnusedMember.Local

        #endregion

        #region Tools enumerator

        /// <summary>
        /// Map tools enumeration
        /// </summary>
        public enum Tools
        {
            /// <summary>
            /// Pan
            /// </summary>
            Pan,

            /// <summary>
            /// Zoom in
            /// </summary>
            ZoomIn,

            /// <summary>
            /// Zoom out
            /// </summary>
            ZoomOut,

            /// <summary>
            /// Query bounding boxes for intersection
            /// </summary>
            QueryBox,

            /// <summary>
            /// Attempt true intersection query on geometry
            /// </summary>
            QueryPoint,

            /// <summary>
            /// Zoom window tool
            /// </summary>
            ZoomWindow,

            /// <summary>
            /// Define Point on Map
            /// </summary>
            DrawPoint,

            /// <summary>
            /// Define Line on Map
            /// </summary>
            DrawLine,

            /// <summary>
            /// Define Polygon on Map
            /// </summary>
            DrawPolygon,

            /// <summary>
            /// No active tool
            /// </summary>
            None
        }

        /// <summary>
        /// Enumeration of map query types
        /// </summary>
        public enum MapQueryType
        {
            /// <summary>
            /// Layer set in QueryLayerIndex is the only layers Queried  (Default)
            /// </summary>
            LayerByIndex,

            /// <summary>
            /// All layers are queried
            /// </summary>
            AllLayers,

            /// <summary>
            /// All visible layers are queried
            /// </summary>
            VisibleLayers,

            /// <summary>
            /// Visible layers are queried from Top and down until a layer with an intersecting feature is found 
            /// </summary>
            TopMostLayer
        };


        #endregion

        #region Events

        /// <summary>
        /// MouseEventtype fired from the MapBox control
        /// </summary>
        /// <param name="worldPos"></param>
        /// <param name="imagePos"></param>
        public delegate void MouseEventHandler(Coordinate worldPos, MouseEventArgs imagePos);

        /// <summary>
        /// Fires when mouse moves over the map
        /// </summary>
        public new event MouseEventHandler MouseMove;

        /// <summary>
        /// Fires when map received a mouseclick
        /// </summary>
        public new event MouseEventHandler MouseDown;

        /// <summary>
        /// Fires when mouse is released
        /// </summary>		
        public new event MouseEventHandler MouseUp;

        /// <summary>
        /// Fired when mouse is dragging
        /// </summary>
        public event MouseEventHandler MouseDrag;

        /// <summary>
        /// Fired when the map has been refreshed
        /// </summary>
        public event EventHandler MapRefreshed;

        /// <summary>
        /// Fired when the map is about to change
        /// </summary>
        public event CancelEventHandler MapChanging;

        /// <summary>
        /// Fired when the map has been changed
        /// </summary>
        public event EventHandler MapChanged;

        /// <summary>
        /// Eventtype fired when the zoom was or are being changed
        /// </summary>
        /// <param name="zoom"></param>
        public delegate void MapZoomHandler(double zoom);

        /// <summary>
        /// Fired when the zoom value has changed
        /// </summary>
        public event MapZoomHandler MapZoomChanged;

        /// <summary>
        /// Fired when the map is being zoomed
        /// </summary>
        public event MapZoomHandler MapZooming;

        /// <summary>
        /// Eventtype fired when the map is queried
        /// </summary>
        /// <param name="data"></param>
        public delegate void MapQueryHandler(SharpMap.Data.FeatureDataTable data);

        /// <summary>
        /// Fired when the map is queried
        /// 
        /// Will be fired one time for each layer selected for query depending on QueryLayerIndex and QuerySettings
        /// </summary>
        public event MapQueryHandler MapQueried;

        /// <summary>
        /// Fired when Map is Queried before the first MapQueried event is fired for that query
        /// </summary>
        public event EventHandler MapQueryStarted;

        /// <summary>
        /// Fired when Map is Queried after the last MapQueried event is fired for that query
        /// </summary>
        public event EventHandler MapQueryDone;


        /// <summary>
        /// Eventtype fired when the center has changed
        /// </summary>
        /// <param name="center"></param>
        public delegate void MapCenterChangedHandler(Coordinate center);

        /// <summary>
        /// Fired when the center of the map has changed
        /// </summary>
        public event MapCenterChangedHandler MapCenterChanged;

        /// <summary>
        /// Eventtype fired when the map tool is changed
        /// </summary>
        /// <param name="tool"></param>
        public delegate void ActiveToolChangedHandler(Tools tool);

        /// <summary>
        /// Fired when the active map tool has changed
        /// </summary>
        public event ActiveToolChangedHandler ActiveToolChanged;

        /// <summary>
        /// Eventtype fired when a new geometry has been defined
        /// </summary>
        /// <param name="geometry">New Geometry</param>
        public delegate void GeometryDefinedHandler(IGeometry geometry);

        /// <summary>
        /// Fired when a new polygon has been defined
        /// </summary>
        public event GeometryDefinedHandler GeometryDefined;

        #endregion

        private static int _defaultColorIndex;

        private static readonly Color[] DefaultColors =
            new[]
                {
                    Color.DarkRed,
                    Color.DarkGreen,
                    Color.DarkBlue,
                    Color.Orange,
                    Color.Cyan,
                    Color.Black,
                    Color.Purple,
                    Color.Yellow,
                    Color.LightBlue,
                    Color.Fuchsia
                };

        /*
        private const float MinDragScalingBeforeRegen = 0.3333f;
        private const float MaxDragScalingBeforeRegen = 3f;
         */
        private readonly ProgressBar _progressBar;

#if DEBUG
        private readonly Stopwatch _watch = new Stopwatch();
#endif

        //private bool m_IsCtrlPressed;
        private double _wheelZoomMagnitude = -2;
        private Tools _activeTool;
        private double _fineZoomFactor = 10;
        private Map _map;
        private int _queryLayerIndex;
        private Point _dragStartPoint;
        private Point _dragEndPoint;
        private Bitmap _dragImage;
        private Rectangle _rectangle = Rectangle.Empty;
        private bool _dragging;
        private readonly SolidBrush _rectangleBrush = new SolidBrush(Color.FromArgb(210, 244, 244, 244));
        private readonly Pen _rectanglePen = new Pen(Color.FromArgb(244, 244, 244), 1);

        private float _scaling;
        private Image _image = new Bitmap(1, 1);
        private Image _imageBackground = new Bitmap(1, 1);
        private Image _imageStatic = new Bitmap(1, 1);
        private Image _imageVariable = new Bitmap(1, 1);
        private Envelope _imageEnvelope = new Envelope(0, 1, 0, 1);
        private int _imageGeneration;

        private PreviewModes _previewMode;
        // private bool _isRefreshing;
        private List<Coordinate> _pointArray = new List<Coordinate>();
        private bool _showProgress;
        private bool _zoomToPointer = true;
        private bool _setActiveToolNoneDuringRedraw;
        private bool _shiftButtonDragRectangleZoom = true;
        private bool _focusOnHover;
        private bool _panOnClick = true;
        private float _queryGrowFactor = 5f;
        private MapQueryType _mapQueryMode = MapQueryType.LayerByIndex;

        private readonly IMessageFilter _mousePreviewFilter;

        /// <summary>
        /// Assigns a random color to a vector layers style
        /// </summary>
        /// <param name="layer"></param>
        public static void RandomizeLayerColors(VectorLayer layer)
        {
            layer.Style.EnableOutline = true;
            layer.Style.Fill = new SolidBrush(Color.FromArgb(80, DefaultColors[_defaultColorIndex % DefaultColors.Length]));
            layer.Style.Outline =
                new Pen(
                    Color.FromArgb(100,
                                   DefaultColors[
                                       (_defaultColorIndex + ((int)(DefaultColors.Length * 0.5))) % DefaultColors.Length]),
                    1f);
            _defaultColorIndex++;
        }

        /// <summary>
        /// Gets or sets a value on whether to report progress of map generation
        /// </summary>
        [Description("Define if the progress Bar is shown")]
        [Category("Appearance")]
        public bool ShowProgressUpdate
        {
            get { return _showProgress; }

            set
            {
                _showProgress = value;
                _progressBar.Visible = _showProgress;
            }
        }

        /// <summary>
        /// Gets or sets whether the "go-to-cursor-on-click" feature is enabled or not (even if enabled it works only if the active tool is Pan)
        /// </summary>
        [Description(
            "Sets whether the \"go-to-cursor-on-click\" feature is enabled or not (even if enabled it works only if the active tool is Pan)"
            )]
        [DefaultValue(true)]
        [Category("Behavior")]
        public bool PanOnClick
        {
            get { return _panOnClick; }
            set
            {
                ActiveTool = Tools.Pan;
                _panOnClick = value;

            }
        }

        /// <summary>
        /// Sets whether the mapcontrol should automatically grab focus when mouse is hovering the control
        /// </summary>
        [Description("Sets whether the mapcontrol should automatically grab focus when mouse is hovering the control")]
        [DefaultValue(false)]
        [Category("Behavior")]
        public bool TakeFocusOnHover
        {
            get { return _focusOnHover; }
            set { _focusOnHover = value; }
        }

        /// <summary>
        /// Sets whether the mouse wheel should zoom to the pointer location
        /// </summary>
        [Description("Sets whether the mouse wheel should zoom to the pointer location")]
        [DefaultValue(true)]
        [Category("Behavior")]
        public bool ZoomToPointer
        {
            get { return _zoomToPointer; }
            set { _zoomToPointer = value; }
        }

        /// <summary>
        /// Sets ActiveTool to None (and changing cursor) while redrawing the map
        /// </summary>
        [Description("Sets ActiveTool to None (and changing cursor) while redrawing the map")]
        [DefaultValue(false)]
        [Category("Behavior")]
        public bool SetToolsNoneWhileRedrawing
        {
            get { return _setActiveToolNoneDuringRedraw; }
            set { _setActiveToolNoneDuringRedraw = value; }
        }

        /// <summary>
        /// Gets or sets the number of pixels by which a bounding box around the query point should be "grown" prior to perform the query
        /// </summary>
        /// <remarks>Does not apply when querying against boxes.</remarks>
        [Description(
            "Gets or sets the number of pixels by which a bounding box around the query point should be \"grown\" prior to perform the query"
            )]
        [DefaultValue(5)]
        [Category("Behavior")]
        public float QueryGrowFactor
        {
            get { return _queryGrowFactor; }
            set
            {
                if (value < 0) value = 0;
                //if (value > 10)
                _queryGrowFactor = value;
            }
        }


        /// <summary>
        /// Gets or sets the value of the back color for the selection rectangle
        /// </summary>
        [Description("The color of selecting rectangle.")]
        [Category("Appearance")]
        public Color SelectionBackColor
        {
            get { return _rectangleBrush.Color; }
            set
            {
                //if (value != m_RectangleBrush.Color)
                _rectangleBrush.Color = value;
            }
        }

        /// <summary>
        /// Gets or sets the value of the border color for the selection rectangle
        /// </summary>
        [Description("The color of selectiong rectangle frame.")]
        [Category("Appearance")]
        public Color SelectionForeColor
        {
            get { return _rectanglePen.Color; }
            set
            {
                //if (value != m_RectanglePen.Color)
                _rectanglePen.Color = value;
            }
        }

        /// <summary>
        /// Gets the current map image
        /// </summary>
        [Description("The map image currently visualized.")]
        [Category("Appearance")]
        public Image Image
        {
            get
            {

                GetImagesAsyncEnd(null);
                return _image;
            }
        }

        /// <summary>
        /// Gets or sets the amount which a single movement of the mouse wheel zooms by.
        /// </summary>
        [Description(
            "The amount which a single movement of the mouse wheel zooms by. (Negative values are similar as OpenLayers/Google, positive are like ArcMap"
            )]
        [DefaultValue(-2)]
        [Category("Behavior")]
        public double WheelZoomMagnitude
        {
            get { return _wheelZoomMagnitude; }
            set { _wheelZoomMagnitude = value; }
        }

        /// <summary>
        /// Gets or sets the mode used to create preview image while panning or zooming.
        /// </summary>
        [Description("Mode used to create preview image while panning or zooming.")]
        [DefaultValue(PreviewModes.Best)]
        [Category("Behavior")]
        public PreviewModes PreviewMode
        {
            get { return _previewMode; }
            set
            {
                if (!_dragging)
                    _previewMode = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating the amount which the WheelZoomMagnitude is divided by 
        /// when the Control key is pressed. A number greater than 1 decreases 
        /// the zoom, and less than 1 increases it. A negative number reverses it.
        /// </summary>
        [Description("The amount which the WheelZoomMagnitude is divided by " +
                     "when the Control key is pressed. A number greater than 1 decreases " +
                     "the zoom, and less than 1 increases it. A negative number reverses it.")]
        [DefaultValue(10)]
        [Category("Behavior")]
        public double FineZoomFactor
        {
            get { return _fineZoomFactor; }
            set { _fineZoomFactor = value; }
        }

        /// <summary>
        /// Gets or sets a value that enables shortcut to rectangle-zoom by holding down shift-button and drag rectangle
        /// </summary>
        [Description("Enables shortcut to rectangle-zoom by holding down shift-button and drag rectangle")]
        [DefaultValue(true)]
        [Category("Behavior")]
        public bool EnableShiftButtonDragRectangleZoom
        {
            get { return _shiftButtonDragRectangleZoom; }
            set { _shiftButtonDragRectangleZoom = value; }
        }

        /// <summary>
        /// Gets or sets the map reference
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Map Map
        {
            get { return _map; }
            set
            {
                if (value != _map)
                {
                    var cea = new CancelEventArgs(false);
                    OnMapChanging(cea);
                    if (cea.Cancel) return;

                    _map = value;

                    OnMapChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets or sets the index of the active query layer 
        /// </summary>
        public int QueryLayerIndex
        {
            get { return _queryLayerIndex; }
            set { _queryLayerIndex = value; }
        }

        /// <summary>
        /// Gets or sets the mapquerying mode
        /// </summary>
        public MapQueryType MapQueryMode
        {
            get { return _mapQueryMode; }
            set { _mapQueryMode = value; }
        }

        /// <summary>
        /// Sets the active map tool
        /// </summary>
        public Tools ActiveTool
        {
            get { return _activeTool; }
            set
            {
                var check = (value != _activeTool);

                _activeTool = value;

                SetCursor();

                _pointArray = null;

                if (check && ActiveToolChanged != null)
                    ActiveToolChanged(value);
            }
        }

#pragma warning disable 1587
#if DEBUG
        /// <summary>
        /// TimeSpan for refreshing maps
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TimeSpan LastRefreshTime { get; set; }
#endif

        /// <summary>
        /// Initializes a new map
        /// </summary>
        public ObjectMapBox()
#pragma warning restore 1587
        {

            SetStyle(
                ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
            base.DoubleBuffered = true;
            _map = new Map(ClientSize);
            VariableLayerCollection.VariableLayerCollectionRequery += HandleVariableLayersRequery;
            _map.MapNewTileAvaliable += HandleMapNewTileAvaliable;

            _activeTool = Tools.None;
            LostFocus += HandleMapBoxLostFocus;


            _progressBar = new ProgressBar
            {
                Style = ProgressBarStyle.Marquee,
                Location = new Point(2, 2),
                Size = new Size(50, 10)
            };
            Controls.Add(_progressBar);
            _progressBar.Visible = false;


        }

        protected override void OnSizeChanged(EventArgs e)
        {
            if (Map != null)
            {
                if (Size != Map.Size)
                {
                    Map.Size = Size;
                    Refresh();
                }
            }
            base.OnSizeChanged(e);
        }

        private volatile bool _isDisposed;

        /// <summary>
        /// Dispose method
        /// </summary>
        /// <param name="disposing">A parameter indicating that this method is called from either a call to <see cref="Control.Dispose()"/> (<c>true</c>)
        /// or the finalizer (<c>false</c>)</param>
        protected override void Dispose(bool disposing)
        {
            if (_isDisposed || IsDisposed)
                return;

            VariableLayerCollection.VariableLayerCollectionRequery -= HandleVariableLayersRequery;
            if (_map != null)
            {
                _map.MapNewTileAvaliable -= HandleMapNewTileAvaliable;
            }
            LostFocus -= HandleMapBoxLostFocus;

            if (_mousePreviewFilter != null)
                Application.RemoveMessageFilter(_mousePreviewFilter);

            lock (_mapLocker)
            {
                _map = null;

                if (_imageStatic != null)
                {
                    _imageStatic.Dispose();
                    _imageStatic = null;
                }
                if (_imageBackground != null)
                {
                    _imageBackground.Dispose();
                    _imageBackground = null;
                }
                if (_imageVariable != null)
                {
                    _imageVariable.Dispose();
                    _imageVariable = null;
                }
                if (_image != null)
                {
                    _image.Dispose();
                    _image = null;
                }

                if (_dragImage != null)
                {
                    _dragImage.Dispose();
                    _dragImage = null;
                }

                if (_rectanglePen != null)
                {
                    _rectanglePen.Dispose();
                }
                if (_rectangleBrush != null)
                {
                    _rectangleBrush.Dispose();
                }

                base.Dispose(disposing);
                _isDisposed = true;
            }
        }

        #region event handling

        /// <summary>
        /// Handles LostFocus event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleMapBoxLostFocus(object sender, EventArgs e)
        {
            if (!_dragging) return;

            _dragging = false;
            Invalidate(ClientRectangle);
        }

        /// <summary>
        /// Handles need to requery of variable layers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleVariableLayersRequery(object sender, EventArgs e)
        {
            if (IsDisposed || _isDisposed)
                return;

            Image oldRef;
            lock (_mapLocker)
            {
                if (_dragging) return;
                oldRef = _imageVariable;
                _imageVariable = GetMap(_map, _map.VariableLayers, LayerCollectionType.Variable, _map.Envelope);
            }

            UpdateImage(false);
            if (oldRef != null)
                oldRef.Dispose();

            Invalidate();
            Application.DoEvents();
        }

        private void HandleMapNewTileAvaliable(TileLayer sender, Envelope box, Bitmap bm, int sourceWidth,
                                               int sourceHeight, ImageAttributes imageAttributes)
        {
            lock (_backgroundImagesLocker)
            {
                try
                {
                    var min = Point.Round(_map.WorldToImage(box.Min()));
                    var max = Point.Round(_map.WorldToImage(box.Max()));

                    if (IsDisposed == false && _isDisposed == false)
                    {

                        using (var g = Graphics.FromImage(_imageBackground))
                        {

                            g.DrawImage(bm,
                                        new Rectangle(min.X, max.Y, (max.X - min.X), (min.Y - max.Y)),
                                        0, 0,
                                        sourceWidth, sourceHeight,
                                        GraphicsUnit.Pixel,
                                        imageAttributes);

                        }

                        UpdateImage(false);
                    }
                }
                catch (Exception ex)
                {
                    Logger.Warn(ex.Message, ex);
                    //this can be a GDI+ Hell Exception...
                }

            }

        }

        #endregion

        private Image GetMap(Map map, LayerCollection layers, LayerCollectionType layerCollectionType,
                             Envelope extent)
        {
            try
            {
                var width = Width;
                var height = Height;

                if ((layers == null || layers.Count == 0 || width <= 0 || height <= 0))
                {
                    if (layerCollectionType == LayerCollectionType.Background)
                        return new Bitmap(1, 1);
                    return null;
                }

                var retval = new Bitmap(width, height);

                using (var g = Graphics.FromImage(retval))
                {
                    map.RenderMap(g, layerCollectionType, false, true);
                }

                if (layerCollectionType == LayerCollectionType.Variable)
                    retval.MakeTransparent(_map.BackColor);

                return retval;
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.StackTrace);
                Logger.Error("Error while rendering map", ee);

                if (layerCollectionType == LayerCollectionType.Background)
                    return new Bitmap(1, 1);
                return null;
            }
        }


        private readonly object _staticImagesLocker = new object();
        private readonly object _backgroundImagesLocker = new object();
        private readonly object _paintImageLocker = new object();
        private readonly object _mapLocker = new object();

        private void GetImagesAsync(Envelope extent, int imageGeneration)
        {
            lock (_mapLocker)
            {
                if (_isDisposed)
                    return;

                if (imageGeneration < _imageGeneration)
                {
                    /*we're to old*/
                    return;
                }
                var safeMap = _map.Clone();
                _imageVariable = GetMap(safeMap, _map.VariableLayers, LayerCollectionType.Variable, extent);
                lock (_staticImagesLocker)
                {
                    _imageStatic = GetMap(safeMap, _map.Layers, LayerCollectionType.Static, extent);
                }
                lock (_backgroundImagesLocker)
                {
                    _imageBackground = GetMap(safeMap, _map.BackgroundLayer, LayerCollectionType.Background, extent);
                }
            }
        }

        private class GetImageEndResult
        {
            public Tools? Tool { get; set; }
            public Envelope bbox { get; set; }
            public int generation { get; set; }
        }

        private void GetImagesAsyncEnd(GetImageEndResult res)
        {
            //draw only if generation is larger than the current, else we have aldready drawn something newer
            if (res == null || res.generation < _imageGeneration || _isDisposed)
                return;


            if (Logger.IsDebugEnabled)
                Logger.DebugFormat("{2}: {0} - {1}", res.generation, res.bbox, DateTime.Now);


            if ((_setActiveToolNoneDuringRedraw || ShowProgressUpdate) && InvokeRequired)
            {
                try
                {
                    BeginInvoke(new MethodInvoker(delegate
                    {
                        GetImagesAsyncEnd(res);
                    }));

                }
                catch (Exception ex)
                {
                    Logger.Warn(ex.Message, ex);
                }
            }
            else
            {
                try
                {
                    var oldRef = _image;
                    if (Width > 0 && Height > 0)
                    {

                        var bmp = new Bitmap(Width, Height);


                        using (var g = Graphics.FromImage(bmp))
                        {
                            lock (_backgroundImagesLocker)
                            {
                                //Draws the background Image
                                if (_imageBackground != null)
                                {
                                    try
                                    {
                                        g.DrawImageUnscaled(_imageBackground, 0, 0);
                                    }
                                    catch (Exception ex)
                                    {
                                        Logger.Warn(ex.Message, ex);
                                    }
                                }
                            }

                            //Draws the static images
                            if (_staticImagesLocker != null)
                            {
                                try
                                {
                                    if (_imageStatic != null)
                                    {
                                        g.DrawImageUnscaled(_imageStatic, 0, 0);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.StackTrace);
                                    Logger.Warn(ex.Message, ex);
                                }

                            }

                            //Draws the variable Images
                            if (_imageVariable != null)
                            {
                                try
                                {
                                    g.DrawImageUnscaled(_imageVariable, 0, 0);
                                }
                                catch (Exception ex)
                                {
                                    Logger.Warn(ex.Message, ex);
                                }
                            }


                            g.Dispose();
                        }


                        lock (_paintImageLocker)
                        {
                            _image = bmp;
                            _imageEnvelope = res.bbox;
                        }
                    }

                    if (res.Tool.HasValue)
                    {
                        if (_setActiveToolNoneDuringRedraw)
                            ActiveTool = res.Tool.Value;

                        _dragEndPoint = new Point(0, 0);
                        //_isRefreshing = false;

                        if (_setActiveToolNoneDuringRedraw)
                            Enabled = true;

                        if (ShowProgressUpdate)
                        {
                            _progressBar.Enabled = false;
                            _progressBar.Visible = false;
                        }
                    }

                    lock (_paintImageLocker)
                    {
                        if (oldRef != null)
                            oldRef.Dispose();
                    }

                    Invalidate();
                }
                catch (Exception ex)
                {
                    Logger.Warn(ex.Message, ex);
                }

#if DEBUG
                _watch.Stop();
                LastRefreshTime = _watch.Elapsed;
#endif

                try
                {
                    if (MapRefreshed != null)
                    {
                        MapRefreshed(this, null);
                    }
                }
                catch (Exception ee)
                {
                    //Trap errors that occured when calling the eventhandlers
                    Logger.Warn("Exception while calling eventhandler", ee);
                }
            }
        }

        private void UpdateImage(bool forceRefresh)
        {
            if (_isDisposed || IsDisposed)
                return;

            if (((_imageStatic == null && _imageVariable == null && _imageBackground == null) && !forceRefresh) ||
                (Width == 0 || Height == 0)) return;

            Envelope bbox = _map.Envelope;
            if (forceRefresh) // && _isRefreshing == false)
            {
                //_isRefreshing = true;
                Tools oldTool = ActiveTool;
                if (_setActiveToolNoneDuringRedraw)
                {
                    ActiveTool = Tools.None;
                    Enabled = false;
                }

                if (ShowProgressUpdate)
                {
                    _progressBar.Visible = true;
                    _progressBar.Enabled = true;
                }

                int generation = ++_imageGeneration;
                ThreadPool.QueueUserWorkItem(
                    delegate
                    {
                        GetImagesAsync(bbox, generation);
                        GetImagesAsyncEnd(new GetImageEndResult { Tool = oldTool, bbox = bbox, generation = generation });
                    });
            }
            else
            {
                GetImagesAsyncEnd(new GetImageEndResult { Tool = null, bbox = bbox, generation = _imageGeneration });
            }
        }

        private void SetCursor()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(SetCursor));
                return;
            }

            if (_activeTool == Tools.None)
                Cursor = Cursors.Default;
            if (_activeTool == Tools.Pan)
                Cursor = Cursors.Hand;
            else if (_activeTool == Tools.QueryBox || _activeTool == Tools.QueryPoint /*|| _activeTool == Tools.QueryPolygon*/)
                Cursor = Cursors.Help;
            else if (_activeTool == Tools.ZoomIn || _activeTool == Tools.ZoomOut || _activeTool == Tools.ZoomWindow)
                Cursor = Cursors.Cross;
            else if (_activeTool == Tools.DrawPoint || _activeTool == Tools.DrawPolygon || _activeTool == Tools.DrawLine)
                Cursor = Cursors.Cross;
        }


        /// <summary>
        /// Refreshes the map
        /// </summary>
        public override void Refresh()
        {
            try
            {
                //Protect against cross-thread operations...
                //We need this since we're modifying the cursor
                if (InvokeRequired)
                {
                    Invoke(new MethodInvoker(Refresh));
                    return;
                }
#if DEBUG
                _watch.Reset();
                _watch.Start();
#endif
                if (_map != null)
                {
                    _map.Size = ClientSize;
                    if ((_map.Layers == null || _map.Layers.Count == 0) &&
                        (_map.BackgroundLayer == null || _map.BackgroundLayer.Count == 0) &&
                        (_map.VariableLayers == null || _map.VariableLayers.Count == 0))
                        _image = null;
                    else
                    {
                        Cursor c = Cursor;
                        if (_setActiveToolNoneDuringRedraw)
                        {
                            Cursor = Cursors.WaitCursor;
                        }
                        UpdateImage(true);
                        if (_setActiveToolNoneDuringRedraw)
                        {
                            Cursor = c;
                        }
                    }

                    base.Refresh();
                    Invalidate();



                }
            }
            catch (Exception ex)
            {
                Logger.Warn(ex.Message, ex);
            }
        }


        private static Boolean IsControlPressed
        {
            get { return (ModifierKeys & Keys.ControlKey) == Keys.ControlKey; }
        }

        /// <summary>
        /// Invokes the <see cref="E:System.Windows.Forms.Control.MouseHover"/>-event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.EventArgs"/> that contains the event arguments.</param>
        protected override void OnMouseHover(EventArgs e)
        {
            if (_focusOnHover)
                TestAndGrabFocus();
            base.OnMouseHover(e);
        }

        private void TestAndGrabFocus()
        {
            if (!Focused)
            {
                var isFocused = Focus();
                Logger.Debug("Focused: " + isFocused);
            }
        }

        private System.Timers.Timer _mouseWheelRefreshTimer;

        /// <summary>
        /// Invokes the <see cref="E:System.Windows.Forms.Control.MouseWheel"/>-event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs"/> that contains the event arguments.</param>
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);

            if (_map != null)
            {
                //If zoomToPointer is set, we first need to center the map around the mouse-location
                //Then Zoom in the map
                //Then pan the map back to it's original shift to have it still centered simultanously
                if (_zoomToPointer)
                    _map.Center = _map.ImageToWorld(new PointF(e.X, e.Y), true);

                var scale = (e.Delta / 120.0);
                var scaleBase = 1 + (_wheelZoomMagnitude / (10 * (IsControlPressed ? _fineZoomFactor : 1)));

                _map.Zoom *= Math.Pow(scaleBase, scale);

                //If zoomtoPointer, move the map back to MousePointer is over same place
                if (_zoomToPointer)
                {
                    var newCenterX = (Width / 2f) + (Width / 2f - e.X);
                    var newCenterY = (Height / 2f) + (Height / 2f - e.Y);

                    var newCenter = _map.ImageToWorld(new PointF(newCenterX, newCenterY), true);
                    var centerChanged = !newCenter.Equals(_map.Center);
                    _map.Center = newCenter;
                    if (centerChanged && MapCenterChanged != null)
                    {
                        MapCenterChanged(_map.Center);
                    }
                }

                if (MapZoomChanged != null)
                    MapZoomChanged(_map.Zoom);

                Invalidate();

                if (_mouseWheelRefreshTimer == null)
                {
                    _mouseWheelRefreshTimer = new System.Timers.Timer(50);
                    _mouseWheelRefreshTimer.Elapsed += TimerUpdate;
                    _mouseWheelRefreshTimer.Enabled = true;
                    _mouseWheelRefreshTimer.AutoReset = false;
                    _mouseWheelRefreshTimer.Start();
                }
                else
                {
                    _mouseWheelRefreshTimer.Stop();
                    _mouseWheelRefreshTimer.Start();
                }
            }
        }

        private void TimerUpdate(object state, System.Timers.ElapsedEventArgs args)
        {
            Logger.Debug("TimerRefresh");
            if (MapZoomChanged != null)
                MapZoomChanged(_map.Zoom);
            Refresh();
        }

        /// <summary>
        /// Invokes the <see cref="E:System.Windows.Forms.Control.MouseDown"/>-event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs"/> that contains the event arguments.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (_map != null)
            {
                if (MouseDown != null)
                    MouseDown(_map.ImageToWorld(new Point(e.X, e.Y)), e);
            }
        }

        /// <summary>
        /// Invokes the <see cref="E:System.Windows.Forms.Control.MouseMove"/>-event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs"/> that contains the event arguments.</param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (_map != null)
            {
                Coordinate p = _map.ImageToWorld(new Point(e.X, e.Y));

                if (MouseMove != null)
                    MouseMove(p, e);


            }
        }


        /// <summary>
        /// Invokes the <see cref="E:SharpMap.Forms.MapBox.MapChanging"/>-event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.ComponentModel.CancelEventArgs"/> that contains the event arguments.</param>
        protected virtual void OnMapChanging(CancelEventArgs e)
        {
            if (MapChanging != null) MapChanging(this, e);
            if (e.Cancel)
                return;

            if (_map != null)
            {
                VariableLayerCollection.VariableLayerCollectionRequery -= HandleVariableLayersRequery;
                _map.MapNewTileAvaliable -= HandleMapNewTileAvaliable;
            }
        }

        /// <summary>
        /// Invokes the <see cref="E:SharpMap.Forms.MapBox.MapChanged"/>-event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.EventArgs"/> that contains the event arguments.</param>
        protected virtual void OnMapChanged(EventArgs e)
        {
            if (_map != null)
            {
                VariableLayerCollection.VariableLayerCollectionRequery += HandleVariableLayersRequery;
                _map.MapNewTileAvaliable += HandleMapNewTileAvaliable;
                Refresh();
            }

            if (MapChanged != null) MapChanged(this, e);
        }

        private Point ClipPoint(Point p)
        {
            var x = p.X < 0 ? 0 : (p.X > ClientSize.Width ? ClientSize.Width : p.X);
            var y = p.Y < 0 ? 0 : (p.Y > ClientSize.Height ? ClientSize.Height : p.Y);
            return new Point(x, y);
        }

        private static Rectangle GenerateRectangle(Point p1, Point p2)
        {
            var x = Math.Min(p1.X, p2.X);
            var y = Math.Min(p1.Y, p2.Y);
            var width = Math.Abs(p2.X - p1.X);
            var height = Math.Abs(p2.Y - p1.Y);

            return new Rectangle(x, y, width, height);
        }
        public bool IsDisplayCompass = true;
        /// <summary>
        /// Invokes the <see cref="E:System.Windows.Forms.Control.Paint"/>-event.
        /// </summary>
        /// <param name="pe">A <see cref="T:System.Windows.Forms.PaintEventArgs"/> that contains the event arguments.</param>
        protected override void OnPaint(PaintEventArgs pe)
        {
            try
            {
                if (_image != null && _image.PixelFormat != PixelFormat.Undefined)
                {
                    lock (_paintImageLocker)
                    {
                        if (_map.Envelope.Equals(_imageEnvelope))
                        {
                            pe.Graphics.DrawImageUnscaled(_image, 0, 0);
                        }
                        else
                        {
                            var ul = _map.WorldToImage(_imageEnvelope.TopLeft());
                            var lr = _map.WorldToImage(_imageEnvelope.BottomRight());
                            pe.Graphics.DrawImage(_image, RectangleF.FromLTRB(ul.X, ul.Y, lr.X, lr.Y));
                        }
                    }
                }
               

                base.OnPaint(pe);

                /*Draw Floating Map-Decorations*/
                if (_map != null && _map.Decorations != null)
                {
                    foreach (SharpMap.Rendering.Decoration.IMapDecoration md in _map.Decorations)
                    {
                        md.Render(pe.Graphics, _map);
                    }
                }
            }
            catch (Exception ee)
            {
                Logger.Error(ee);
            }
        }

        /// <summary>
        /// Invokes the <see cref="E:System.Windows.Forms.Control.MouseUp"/>-event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.MouseEventArgs"/> that contains the event arguments.</param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (_map != null)
            {
                if (MouseUp != null)
                    MouseUp(_map.ImageToWorld(new Point(e.X, e.Y)), e);


            }
        }

        private List<ICanQueryLayer> GetLayersToQuery()
        {
            var layersToQuery = new List<ICanQueryLayer>();
            switch (_mapQueryMode)
            {
                case MapQueryType.LayerByIndex:
                    if (_map.Layers.Count > _queryLayerIndex && _queryLayerIndex > -1)
                    {
                        var layer = _map.Layers[_queryLayerIndex] as ICanQueryLayer;
                        if (layer != null)
                        {
                            layersToQuery.Add(layer);
                        }
                    }
                    break;
                case MapQueryType.TopMostLayer:
                case MapQueryType.VisibleLayers:
                    foreach (var layer in _map.Layers)
                    {
                        var cqLayer = layer as ICanQueryLayer;
                        if (cqLayer != null && layer.Enabled && layer.MinVisible < _map.Zoom &&
                            layer.MaxVisible >= _map.Zoom && cqLayer.IsQueryEnabled)
                            layersToQuery.Add(cqLayer);
                    }
                    if (_mapQueryMode == MapQueryType.TopMostLayer)
                        layersToQuery.Reverse();
                    break;
                default:
                    foreach (var layer in _map.Layers)
                    {
                        var cqLayer = layer as ICanQueryLayer;
                        if (cqLayer != null && cqLayer.IsQueryEnabled)
                            layersToQuery.Add(cqLayer);
                    }
                    break;
            }

            return layersToQuery;
        }




        private static void GetBounds(Coordinate p1, Coordinate p2,
                                      out Coordinate lowerLeft, out Coordinate upperRight)
        {
            lowerLeft = new Coordinate(Math.Min(p1.X, p2.X), Math.Min(p1.Y, p2.Y));
            upperRight = new Coordinate(Math.Max(p1.X, p2.X), Math.Max(p1.Y, p2.Y));

            if (Logger.IsDebugEnabled)
            {
                Logger.Debug("p1: " + p1);
                Logger.Debug("p2: " + p2);
                Logger.Debug("lowerLeft: " + lowerLeft);
                Logger.Debug("upperRight: " + upperRight);
            }
        }


    }
}
