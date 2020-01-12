using ScintillaNET;
using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Diagnostics;
using System.Threading;
using Reloaded.Injector;
using WeAreDevs_API;
using EasyExploits;
using System.IO;
using Microsoft.Win32;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Net;
using System.ComponentModel;
using TsuSploit.External_API;

namespace TsuSploit
{
    public partial class TsuMain : Form
    {
        public static string Version = "1.0.1";
        public TsuMain()
        {
            InitializeComponent();
            Text = RandomString(8) + " [ZeroTsuSploit]";
            ScintillaLoad();
            RegSet();
            ListBoxInit();
            StatusChecker.Start(); //To hide the easter egg.
            ServicePointManager.ServerCertificateValidationCallback += new RemoteCertificateValidationCallback(AlwaysGoodCertificate);
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            try
            {
                using (WebClient wc = new WebClient())
                {
                    LatestV.Text = wc.DownloadString(new Uri("https://raw.githubusercontent.com/teppyboy/TsuSploit/master/TsuSploit/latest.txt"));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to download latest version data! Using ?.?.?");
                LatestV.Text = "Latest Version: ?.?.?";
            }
            CurrentV.Text = "Current Version: " + Version;
            StartTimer.Start(); // Make sure all ScintillaNET loaded before visible... 
            FocusCheck.Start();
        }
        internal static readonly char[] chars =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
        private bool isMinimizing, isExiting, isHoverOp, isStarting, isHoverOpE, isInjecting;
        private string DefaultDir;
        private int Wait20, Waiter, WaitBeforeInject;
        private Mutex mutex = new Mutex();
        private void DirSearch(ListBox lsb, string sDir)
        {
            try
            {
                foreach (string f in Directory.GetFiles(sDir))
                {
                    lsb.Items.Add(f.Replace(DefaultDir + @"\",""));
                }
                foreach (string d in Directory.GetDirectories(sDir))
                { 
                    DirSearch(lsb, d);
                }
            }
            catch (Exception excpt)
            {
                MessageBox.Show("Failed to get files & directories from " + sDir + "\nLogs\n" + excpt.Message);
            }
        }
        private static bool AlwaysGoodCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors policyErrors)
        {
            return true;
        }
        private void ListBoxInit()
        {
            Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "Scripts");
            ListBox.Items.Clear();
            DirSearch(ListBox, DefaultDir);
        }
        private void ScintillaLoad()
        {
            BestTextBox.WrapMode = WrapMode.None;
            BestTextBox.IndentationGuides = IndentView.LookBoth;
            InitColors();
            ScintillaSyntaxColoring();
            InitNumberMargin();
            InitBookmarkMargin();
            InitCodeFolding();
        }
        private void RegSet()
        {
            var a = Registry.CurrentUser.OpenSubKey("ZeroTsuSploit");
            if (a != null)
            {
                var Hover = a.GetValue("HoverOpacity");
                if (Hover != null)
                {
                    try
                    {
                        HoverOpacity.Checked = Convert.ToBoolean(Hover);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Failed to set HoverOpacity.");
                        Console.WriteLine(ex);
                    }
                }
                var TopM0st = a.GetValue("TopMost");
                if (TopM0st != null)
                {
                    try
                    {
                        TopMostCheck.Checked = Convert.ToBoolean(TopM0st);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Failed to set TopMostCheck.");
                        Console.WriteLine(ex);
                    }
                }
                var MoreRBX = a.GetValue("MultiRBX");
                if (MoreRBX != null)
                {
                    try
                    {
                        MultiRBX.Checked = Convert.ToBoolean(MoreRBX);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Failed to set MultiRBX.");
                        Console.WriteLine(ex);
                    }
                }
                var ApiTypes = a.GetValue("ApiMode");
                if (ApiTypes != null)
                {
                    try
                    {
                        if (ApiTypes.ToString() == "WeAreDevs API" || ApiTypes.ToString() == "EasyExploits API" || ApiTypes.ToString() == "ApiModule" || ApiTypes.ToString() == "SirHurtAPI" || ApiTypes.ToString() == "Krnl")
                        {
                            APIType.Text = ApiTypes.ToString();
                        }
                        else
                            Console.WriteLine("No API selected or Invaild API.\nAPI Name: " + ApiTypes.ToString());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Failed to set APIType.");
                        Console.WriteLine(ex);
                    }
                }
                var AutoIJ = a.GetValue("AutoHook");
                if (AutoIJ != null)
                {
                    try
                    {
                        AutoHook.Checked = Convert.ToBoolean(AutoIJ);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Failed to set AutoHook.");
                        Console.WriteLine(ex);
                    }
                }
                var AutoIJDelay = a.GetValue("AutoHookDelay");
                if (AutoIJDelay != null)
                {
                    bool SUCCess = int.TryParse(AutoIJDelay.ToString(), out WaitBeforeInject);
                    if (!SUCCess)
                    {
                        WaitBeforeInject = 10;
                        Console.WriteLine("Failed to set WaitBeforeInject.");
                        Console.WriteLine("Use default value: 10");
                    }
                    WaitInjectTime.Text = WaitBeforeInject.ToString();
                }
                else
                {
                    WaitBeforeInject = 10;
                    WaitInjectTime.Text = WaitBeforeInject.ToString();
                    Console.WriteLine("Failed to set WaitBeforeInject.");
                    Console.WriteLine("Use default value: 10");
                }
                var DefDir = a.GetValue("DefaultDir");
                if (DefDir != null)
                {
                    try
                    {
                        if (DefDir.ToString() == "")
                        {
                            DefaultDir = AppDomain.CurrentDomain.BaseDirectory + "Scripts";
                            Console.WriteLine("Failed to set DefaultDir, using default dir (Scripts)...");
                        }
                        else
                        DefaultDir = DefDir.ToString();
                    }
                    catch (Exception ex)
                    {
                        DefaultDir = AppDomain.CurrentDomain.BaseDirectory + "Scripts";
                        Console.WriteLine("Failed to set DefaultDir, using default dir (Scripts)...");
                        Console.WriteLine(ex);
                    }
                }
                else
                {
                    DefaultDir = AppDomain.CurrentDomain.BaseDirectory + "Scripts";
                    Console.WriteLine("Failed to set DefaultDir, using default dir (Scripts)...");
                }
                ScriptPath.Text = DefaultDir;
            }
        }
        private bool MouseIsOverControl(Control btn)
        {
            if (btn.ClientRectangle.Contains(btn.PointToClient(Cursor.Position)))
            {
                return true;
            }
            return false;
        }
        public static string RandomString(int size)
        {
            byte[] data = new byte[4 * size];
            using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
            {
                crypto.GetBytes(data);
            }
            StringBuilder result = new StringBuilder(size);
            for (int i = 0; i < size; i++)
            {
                var rnd = BitConverter.ToUInt32(data, i * 4);
                var idx = rnd % chars.Length;

                result.Append(chars[idx]);
            }

            return result.ToString();
        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();
        private void InitColors()
        {
            BestTextBox.SetSelectionBackColor(true, IntToColor(0x114D9C));
        }
        public static bool ApplicationIsActivated()
        {
            var activatedHandle = GetForegroundWindow();
            if (activatedHandle == IntPtr.Zero)
            {
                return false;       // No window is currently activated
            }
            var procId = Process.GetCurrentProcess().Id;
            int activeProcId;
            GetWindowThreadProcessId(activatedHandle, out activeProcId);
            return activeProcId == procId;
        }
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        private static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int GetWindowThreadProcessId(IntPtr handle, out int processId);
        private void ScintillaSyntaxColoring()
        {
            var alphaChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var numericChars = "0123456789";
            var accentedChars = "ŠšŒœŸÿÀàÁáÂâÃãÄäÅåÆæÇçÈèÉéÊêËëÌìÍíÎîÏïÐðÑñÒòÓóÔôÕõÖØøÙùÚúÛûÜüÝýÞþßö";
            // Configuring the default style with properties
            // we have common to every lexer style saves time.
            BestTextBox.Styles[ScintillaNET.Style.Default].Font = "Consolas";
            BestTextBox.Styles[ScintillaNET.Style.Default].Size = 10;
            BestTextBox.Styles[Style.Default].BackColor = IntToColor(0x212121);
            BestTextBox.Styles[Style.Default].ForeColor = IntToColor(0xFFFFFF);
            BestTextBox.StyleClearAll();
            // Configure the Lua lexer styles
            BestTextBox.Styles[ScintillaNET.Style.Lua.Default].ForeColor = Color.Silver;
            BestTextBox.Styles[ScintillaNET.Style.Lua.Comment].ForeColor = Color.SeaGreen;
            BestTextBox.Styles[ScintillaNET.Style.Lua.CommentLine].ForeColor = Color.SeaGreen;
            BestTextBox.Styles[ScintillaNET.Style.Lua.Number].ForeColor = Color.Green;
            BestTextBox.Styles[ScintillaNET.Style.Lua.Word].ForeColor = Color.Blue;
            BestTextBox.Styles[ScintillaNET.Style.Lua.Word2].ForeColor = Color.BlueViolet;
            BestTextBox.Styles[ScintillaNET.Style.Lua.Word3].ForeColor = Color.DarkSlateBlue;
            BestTextBox.Styles[ScintillaNET.Style.Lua.Word4].ForeColor = Color.DarkBlue;
            BestTextBox.Styles[ScintillaNET.Style.Lua.String].ForeColor = Color.Red;
            BestTextBox.Styles[ScintillaNET.Style.Lua.Character].ForeColor = Color.Red;
            BestTextBox.Styles[ScintillaNET.Style.Lua.LiteralString].ForeColor = Color.Red;
            BestTextBox.Styles[ScintillaNET.Style.Lua.StringEol].BackColor = Color.Pink;
            BestTextBox.Styles[ScintillaNET.Style.Lua.Operator].ForeColor = Color.Purple;
            BestTextBox.Styles[ScintillaNET.Style.Lua.Preprocessor].ForeColor = Color.Maroon;
            BestTextBox.Lexer = Lexer.Lua;
            BestTextBox.WordChars = alphaChars + numericChars + accentedChars;
            // Keywords
            BestTextBox.SetKeywords(0, "game and break do else elseif end for function if in local nil not or repeat return then until while" + " false true" + " goto");
            // Basic Functions
            BestTextBox.SetKeywords(1, "assert collectgarbage dofile error _G getmetatable ipairs loadfile next pairs pcall print rawequal rawget rawset setmetatable tonumber tostring type _VERSION xpcall string table math coroutine io os debug" + " getfenv gcinfo load loadlib loadstring require select setfenv unpack _LOADED LUA_PATH _REQUIREDNAME package rawlen package bit32 utf8 _ENV readfile writefile setclipboard getclipboard MouseButton1Click MouseButton1Press MouseButton1Release MouseButton2Click MouseButton2Press MouseButton2Release WRDAPI.ShowConsole WRDAPI.HideConsole WRDAPI.error WRDAPI.warn WRDAPI.log WRDAPI.InfoMsg WRDAPI.ErrorMsg HttpGet getrawmetatable setrawmetatable getgenv setreadonly isreadonly MouseMoveRel MouseScroll OpenWebsite isRobloxFocused HttpGetAsync decompile");
            // String Manipulation & Mathematical
            BestTextBox.SetKeywords(2, "string.byte string.char string.dump string.find string.format string.gsub string.len string.lower string.rep string.sub string.upper table.concat table.insert table.remove table.sort math.abs math.acos math.asin math.atan math.atan2 math.ceil math.cos math.deg math.exp math.floor math.frexp math.ldexp math.log math.max math.min math.pi math.pow math.rad math.random math.randomseed math.sin math.sqrt math.tan" + " string.gfind string.gmatch string.match string.reverse string.pack string.packsize string.unpack table.foreach table.foreachi table.getn table.setn table.maxn table.pack table.unpack table.move math.cosh math.fmod math.huge math.log10 math.modf math.mod math.sinh math.tanh math.maxinteger math.mininteger math.tointeger math.type math.ult" + " bit32.arshift bit32.band bit32.bnot bit32.bor bit32.btest bit32.bxor bit32.extract bit32.replace bit32.lrotate bit32.lshift bit32.rrotate bit32.rshift" + " utf8.char utf8.charpattern utf8.codes utf8.codepoint utf8.len utf8.offset");
            // Input and Output Facilities and System Facilities
            BestTextBox.SetKeywords(3, "coroutine.create coroutine.resume coroutine.status coroutine.wrap coroutine.yield io.close io.flush io.input io.lines io.open io.output io.read io.tmpfile io.type io.write io.stdin io.stdout io.stderr os.clock os.date os.difftime os.execute os.exit os.getenv os.remove os.rename os.setlocale os.time os.tmpname" + " coroutine.isyieldable coroutine.running io.popen module package.loaders package.seeall package.config package.searchers package.searchpath" + " require package.cpath package.loaded package.loadlib package.path package.preload");
            BestTextBox.SetProperty("fold", "1");
            BestTextBox.SetProperty("fold.compact", "1");
            BestTextBox.Margins[2].Type = MarginType.Symbol;
            BestTextBox.Margins[2].Mask = Marker.MaskFolders;
            BestTextBox.Margins[2].Sensitive = true;
            BestTextBox.Margins[2].Width = 20;
            for (int i = 25; i <= 31; i++)
            {
                BestTextBox.Markers[i].SetForeColor(SystemColors.ControlLightLight);
                BestTextBox.Markers[i].SetBackColor(SystemColors.ControlDark);
            }
            BestTextBox.Markers[Marker.Folder].Symbol = MarkerSymbol.BoxPlus;
            BestTextBox.Markers[Marker.FolderOpen].Symbol = MarkerSymbol.BoxMinus;
            BestTextBox.Markers[Marker.FolderEnd].Symbol = MarkerSymbol.BoxPlusConnected;
            BestTextBox.Markers[Marker.FolderMidTail].Symbol = MarkerSymbol.TCorner;
            BestTextBox.Markers[Marker.FolderOpenMid].Symbol = MarkerSymbol.BoxMinusConnected;
            BestTextBox.Markers[Marker.FolderSub].Symbol = MarkerSymbol.VLine;
            BestTextBox.Markers[Marker.FolderTail].Symbol = MarkerSymbol.LCorner;
            BestTextBox.AutomaticFold = (AutomaticFold.Show | AutomaticFold.Click | AutomaticFold.Change);
        }

        private const int BACK_COLOR = 0x2A211C;
        private const int FORE_COLOR = 0xB7B7B7;
        private const int NUMBER_MARGIN = 1;
        private const int BOOKMARK_MARGIN = 2;
        private const int BOOKMARK_MARKER = 2;
        private const int FOLDING_MARGIN = 3;
        private const bool CODEFOLDING_CIRCULAR = true;
        private void InitNumberMargin()
        {
            BestTextBox.Styles[Style.LineNumber].BackColor = IntToColor(BACK_COLOR);
            BestTextBox.Styles[Style.LineNumber].ForeColor = IntToColor(FORE_COLOR);
            BestTextBox.Styles[Style.IndentGuide].ForeColor = IntToColor(FORE_COLOR);
            BestTextBox.Styles[Style.IndentGuide].BackColor = IntToColor(BACK_COLOR);
            var nums = BestTextBox.Margins[NUMBER_MARGIN];
            nums.Width = 30;
            nums.Type = MarginType.Number;
            nums.Sensitive = true;
            nums.Mask = 0;
        }

        private void InitBookmarkMargin()
        {
            //TextArea.SetFoldMarginColor(true, IntToColor(BACK_COLOR));
            var margin = BestTextBox.Margins[BOOKMARK_MARGIN];
            margin.Width = 20;
            margin.Sensitive = true;
            margin.Type = MarginType.Symbol;
            margin.Mask = (1 << BOOKMARK_MARKER);
            //margin.Cursor = MarginCursor.Arrow;
            var marker = BestTextBox.Markers[BOOKMARK_MARKER];
            marker.Symbol = MarkerSymbol.Circle;
            marker.SetBackColor(IntToColor(0xFF003B));
            marker.SetForeColor(IntToColor(0x000000));
            marker.SetAlpha(100);
        }

        private void InitCodeFolding()
        {

            BestTextBox.SetFoldMarginColor(true, IntToColor(BACK_COLOR));
            BestTextBox.SetFoldMarginHighlightColor(true, IntToColor(BACK_COLOR));

            // Enable code folding
            BestTextBox.SetProperty("fold", "1");
            BestTextBox.SetProperty("fold.compact", "1");

            // Configure a margin to display folding symbols
            BestTextBox.Margins[FOLDING_MARGIN].Type = MarginType.Symbol;
            BestTextBox.Margins[FOLDING_MARGIN].Mask = Marker.MaskFolders;
            BestTextBox.Margins[FOLDING_MARGIN].Sensitive = true;
            BestTextBox.Margins[FOLDING_MARGIN].Width = 20;

            // Set colors for all folding markers
            for (int i = 25; i <= 31; i++)
            {
                BestTextBox.Markers[i].SetForeColor(IntToColor(BACK_COLOR)); // styles for [+] and [-]
                BestTextBox.Markers[i].SetBackColor(IntToColor(FORE_COLOR)); // styles for [+] and [-]
            }

            // Configure folding markers with respective symbols
            BestTextBox.Markers[Marker.Folder].Symbol = CODEFOLDING_CIRCULAR ? MarkerSymbol.CirclePlus : MarkerSymbol.BoxPlus;
            BestTextBox.Markers[Marker.FolderOpen].Symbol = CODEFOLDING_CIRCULAR ? MarkerSymbol.CircleMinus : MarkerSymbol.BoxMinus;
            BestTextBox.Markers[Marker.FolderEnd].Symbol = CODEFOLDING_CIRCULAR ? MarkerSymbol.CirclePlusConnected : MarkerSymbol.BoxPlusConnected;
            BestTextBox.Markers[Marker.FolderMidTail].Symbol = MarkerSymbol.TCorner;
            BestTextBox.Markers[Marker.FolderOpenMid].Symbol = CODEFOLDING_CIRCULAR ? MarkerSymbol.CircleMinusConnected : MarkerSymbol.BoxMinusConnected;
            BestTextBox.Markers[Marker.FolderSub].Symbol = MarkerSymbol.VLine;
            BestTextBox.Markers[Marker.FolderTail].Symbol = MarkerSymbol.LCorner;

            // Enable automatic folding
            BestTextBox.AutomaticFold = (AutomaticFold.Show | AutomaticFold.Click | AutomaticFold.Change);

        }

        private void BestTextBox_MarginClick(object sender, MarginClickEventArgs e)
        {
            if (e.Margin == BOOKMARK_MARGIN)
            {
                // Do we have a marker for this line?
                const uint mask = (1 << BOOKMARK_MARKER);
                var line = BestTextBox.Lines[BestTextBox.LineFromPosition(e.Position)];
                if ((line.MarkerGet() & mask) > 0)
                {
                    // Remove existing bookmark
                    line.MarkerDelete(BOOKMARK_MARKER);
                }
                else
                {
                    // Add bookmark
                    line.MarkerAdd(BOOKMARK_MARKER);
                }
            }
        }
        public static Color IntToColor(int rgb)
        {
            return Color.FromArgb(255, (byte)(rgb >> 16), (byte)(rgb >> 8), (byte)rgb);
        }
        private void InjectBtn_Click(object sender, EventArgs e)
        {
            StatusTxt.Text = "Status: Injecting";
            Process[] pname = Process.GetProcessesByName("RobloxPlayerBeta");
            if (pname.Length != 0)
            {
                if (AutoHook.Checked)
                {
                    Console.WriteLine("Auto-Hook is enabled, blocking user from manual inject...");
                    MessageBox.Show("Auto Inject is enabled. Disable Auto Inject to inject manually.", "TsuSploit");
                }
                else
                {
                    if (APIType.Text == "WeAreDevs API")
                    {
                        if (ExploitAPI.isAPIAttached())
                        {
                            Console.WriteLine("Already injected WeAreDevs API.");
                            MessageBox.Show("Already Injected WeAreDevs API", "TsuSploit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        else if (ExploitAPI.IsUpdated())
                        {
                            if (ExploitAPI.DownloadLatestVersion())
                            {
                                foreach (var rbx in Process.GetProcessesByName("RobloxPlayerBeta"))
                                {
                                    try
                                    {
                                        var injector = new Injector(rbx);
                                        if (injector.Inject(AppDomain.CurrentDomain.BaseDirectory + "exploit-main.dll") != 0)
                                        {
                                            Console.WriteLine("Injected WeAreDevs API.");
                                            ExploitAPI.SendLuaScript(new WebClient().DownloadString("http://cdn.tretrauit.epizy.com/files/RBLX_Scripts/Generic/TsuSploit%20Executor.lua"));
                                            //MessageBox.Show("Injected WeAreDevs API", "TsuSploit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        else
                                        {
                                            Console.WriteLine("Failed to inject WeAreDevs API.");
                                            //MessageBox.Show("Failed to inject WeAreDevs API", "TsuSploit", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                        injector.Dispose();
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine("Failed to inject WeAreDevs API [T/C].");
                                        Console.WriteLine(ex);
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Failed to download exploit-main.dll.");
                                //MessageBox.Show("Failed to download exploit-main.dll", "TsuSploit", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else if (!ExploitAPI.isAPIAttached())
                        {
                            Console.WriteLine("WeAreDevs API is patched.");
                            //MessageBox.Show("WeAreDevs API is currently patched... Please wait for the developers to fix it! Meanwhile, check wearedevs.net for updates/info.", "TsuSploit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else if (APIType.Text == "EasyExploits API")
                    {
                        if (Module.namedPipeExist("ocybedam"))
                        {
                            Console.WriteLine("Already injected EasyExploits API");
                            //MessageBox.Show("Already Injected EasyExploit API", "TsuSploit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        else if (!Module.DownloadDLL())
                        {
                            Console.WriteLine("Failed to download EasyExploitsDLL.dll");
                            //MessageBox.Show("Failed to download EasyExploitsDLL.dll", "TsuSploit", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        foreach (var rbx in Process.GetProcessesByName("RobloxPlayerBeta"))
                        {
                            try
                            {
                                var injector = new Injector(rbx);
                                if (injector.Inject(AppDomain.CurrentDomain.BaseDirectory + "EasyExploitsDLL.dll") != 0)
                                {
                                    Console.WriteLine("Injected EasyExploits API.");
                                    Module.ExecuteScript(new WebClient().DownloadString("http://cdn.tretrauit.epizy.com/files/RBLX_Scripts/Generic/TsuSploit%20Executor.lua"));
                                    //MessageBox.Show("Injected EasyExploits API", "TsuSploit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    Console.WriteLine("Failed to inject EasyExploits API.");
                                    //MessageBox.Show("Failed to inject EasyExploits API", "TsuSploit", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                injector.Dispose();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Failed to inject EasyExploits API [T/C].");
                                Console.WriteLine(ex);
                            }
                        }
                    }
                    else if (APIType.Text == "ApiModule")
                    {
                        if (ApiModule.ApiModule.namedPipeExist("462B9C47BB16AF43C5CF0BB7C970349DCEA20D1BFB8AA87E688BAF8E93553B0F"))
                        {
                            Console.WriteLine("Already injected ApiModule.");
                            //MessageBox.Show("Already Injected ApiModule", "TsuSploit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        else if (!ApiModule.ApiModule.DownloadDLL())
                        {
                            Console.WriteLine("Failed to download ApiModuleDLL.dll");
                            //MessageBox.Show("Failed to download ApiModuleDLL.dll", "TsuSploit", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        foreach (var rbx in Process.GetProcessesByName("RobloxPlayerBeta"))
                        {
                            try
                            {
                                var injector = new Injector(rbx);
                                if (injector.Inject(AppDomain.CurrentDomain.BaseDirectory + "ApiModuleDLL.dll") != 0)
                                {
                                    Console.WriteLine("Injected APiModule.");
                                    ApiModule.ApiModule.ExecuteScript(new WebClient().DownloadString("http://cdn.tretrauit.epizy.com/files/RBLX_Scripts/Generic/TsuSploit%20Executor.lua"));
                                    //MessageBox.Show("Injected APiModule", "TsuSploit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    Console.WriteLine("Failed to inject APiModule");
                                    //MessageBox.Show("Failed to inject APiModule", "TsuSploit", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                injector.Dispose();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Failed to inject ApiModule [T/C].");
                                Console.WriteLine(ex);
                            }
                        }
                    }
                    else if (APIType.Text == "SirHurtAPI")
                    {
                        if (SirHurtAPI.SirHurtAPI.isInjected())
                        {
                            Console.WriteLine("Already injected SirHurtAPI.");
                            //MessageBox.Show("Already Injected SirHurtAPI", "TsuSploit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        else if (!SirHurtAPI.SirHurtAPI.DownloadDll(false))
                        {
                            Console.WriteLine("Failed to download SirHurt.dll");
                            //MessageBox.Show("Failed to download SirHurt.dll", "TsuSploit", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        foreach (var rbx in Process.GetProcessesByName("RobloxPlayerBeta"))
                        {
                            try
                            {
                                var injector = new Injector(rbx);
                                if (injector.Inject(AppDomain.CurrentDomain.BaseDirectory + "SirHurt.dll") != 0)
                                {
                                    Console.WriteLine("Injected SirHurtAPI.");
                                    SirHurtAPI.SirHurtAPI.Execute(new WebClient().DownloadString("http://cdn.tretrauit.epizy.com/files/RBLX_Scripts/Generic/TsuSploit%20Executor.lua"), true);
                                    //MessageBox.Show("Injected SirHurtAPI", "TsuSploit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    Console.WriteLine("Failed to inject SirHurtAPI");
                                    //MessageBox.Show("Failed to inject SirHurtAPI", "TsuSploit", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                injector.Dispose();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Failed to inject SirHurtAPI [T/C].");
                                Console.WriteLine(ex);
                            }
                        }
                    }
                    else if (APIType.Text == "Krnl")
                    {
                        foreach (var rbx in Process.GetProcessesByName("RobloxPlayerBeta"))
                        {
                            try
                            {
                                var injector = new Injector(rbx);
                                if ((injector.Inject(AppDomain.CurrentDomain.BaseDirectory + "krnl2.dll") != 0) && (injector.Inject(AppDomain.CurrentDomain.BaseDirectory + "Indicium-Supra.dll") != 0))
                                {
                                    Console.WriteLine("Injected SirHurtAPI.");
                                    KrnlAPI.Pipe(new WebClient().DownloadString("http://cdn.tretrauit.epizy.com/files/RBLX_Scripts/Generic/TsuSploit%20Executor.lua"));
                                    //MessageBox.Show("Injected SirHurtAPI", "TsuSploit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    Console.WriteLine("Failed to inject SirHurtAPI");
                                    //MessageBox.Show("Failed to inject SirHurtAPI", "TsuSploit", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                injector.Dispose();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Failed to inject Krnl [T/C].");
                                Console.WriteLine(ex);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("No API Selected");
                        MessageBox.Show("No API selected.", "TsuSploit", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                Console.WriteLine("ROBLOX is not running.");
                MessageBox.Show("ROBLOX is not running.", "TsuSploit", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ClearBtn_Click(object sender, EventArgs e)
        {
            BestTextBox.Text = "--[[\nTsuSploit is crappy\nI <3 Zero Two\n]]";
        }

        private void ExecuteLuaC_Click(object sender, EventArgs e)
        {
            Process[] pname = Process.GetProcessesByName("RobloxPlayerBeta");
            if (pname.Length != 0)
            {
                if (APIType.Text == "WeAreDevs API")
                {
                    ExploitAPI.SendLuaCScript(BestTextBox.Text);
                }
                else if (APIType.Text == "")
                {
                    MessageBox.Show("No API selected.", "TsuSploit", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Not supported.", "TsuSploit", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("ROBLOX is not running.", "TsuSploit", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ExecuteLua_Click(object sender, EventArgs e)
        {
            Process[] pname = Process.GetProcessesByName("RobloxPlayerBeta");
            if (pname.Length != 0)
            {
                if (APIType.Text == "WeAreDevs API")
                {
                    ExploitAPI.SendLuaScript(BestTextBox.Text);
                }
                else if (APIType.Text == "EasyExploits API")
                {
                    Module.ExecuteScript(BestTextBox.Text);
                }
                else if (APIType.Text == "ApiModule")
                {
                    ApiModule.ApiModule.ExecuteScript(BestTextBox.Text);
                }
                else if (APIType.Text == "SirHurtAPI")
                {
                    SirHurtAPI.SirHurtAPI.Execute(BestTextBox.Text, true);
                }
                else if (APIType.Text == "Krnl")
                {
                    KrnlAPI.Pipe(BestTextBox.Text);
                }
                else
                    MessageBox.Show("No API selected.", "TsuSploit");
            }
            else
                MessageBox.Show("ROBLOX is not running.", "TsuSploit", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void Title_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            ExitTimer.Start();
        }

        private void MinimizeBtn_Click(object sender, EventArgs e)
        {
            MinimizeTimer.Start();
        }

        private void MinimizeTimer_Tick(object sender, EventArgs e)
        {
            if (!isExiting && !isStarting)
            {
                if (this.Opacity > 0)
                {
                    isMinimizing = true;
                    Opacity -= .05;
                }
                else
                {
                    WindowState = FormWindowState.Minimized;
                    isMinimizing = false;
                    MinimizeTimer.Stop();
                }
            }
        }
        private void StartTimer_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1)
            {
                isStarting = true;
                Opacity += .05;
            }
            else
            {
                if (Wait20 == 20)
                {
                    StartTimer.Stop();
                    isStarting = false;
                }
                else
                {
                    isStarting = true;
                    Wait20++;
                }
            }
        }

        private void ExitTimer_Tick(object sender, EventArgs e)
        {
            if (!isMinimizing && !isStarting)
            {
                if (this.Opacity > 0)
                {
                    isExiting = true;
                    Opacity -= .05;
                }
                else
                {
                    MinimizeTimer.Stop();
                    mutex.Dispose();
                    Environment.Exit(0);
                }
            }
        }

        private void HoverOpacity_CheckedChanged(object sender, EventArgs e)
        {
            var a = Registry.CurrentUser.CreateSubKey("ZeroTsuSploit");
            a.SetValue("HoverOpacity", HoverOpacity.Checked);
            if (HoverOpacity.Checked)
            {
                isHoverOpE = true;
                HoverOp.Start();
            }
            else
            {
                HoverOp.Stop();
                isHoverOpE = false;
            }
        }

        private void MultiRBXTrack_Tick(object sender, EventArgs e)
        {
            Process[] pname = Process.GetProcessesByName("RobloxPlayerBeta");
            if (pname.Length == 0)
            {
                mutex.Dispose();
                mutex = new Mutex(true, "ROBLOX_singletonMutex");
            }
        }

        private void MultiRBX_CheckedChanged(object sender, EventArgs e)
        {
            var a = Registry.CurrentUser.CreateSubKey("ZeroTsuSploit");
            a.SetValue("MultiRBX", MultiRBX.Checked);
            if (MultiRBX.Checked)
            {
                foreach (var proc in Process.GetProcessesByName("RobloxPlayerBeta"))
                {
                    proc.Kill();
                }
                MultiRBXTrack.Start();
            }
            else
            {
                MultiRBXTrack.Stop();
                mutex.Dispose();
            }
        }

        private void StatusChecker_Tick(object sender, EventArgs e)
        {
            Process[] pname = Process.GetProcessesByName("RobloxPlayerBeta");
            if (pname.Length != 0)
            {
                if (APIType.Text == "WeAreDevs API")
                {
                    if (ExploitAPI.isAPIAttached())
                        StatusTxt.Text = "Status: Injected";
                    else
                        StatusTxt.Text = "Status: Not Injected";
                }
                else if (APIType.Text == "EasyExploits API")
                {
                    if (Module.namedPipeExist("ocybedam"))
                        StatusTxt.Text = "Status: Injected";
                    else
                        StatusTxt.Text = "Status: Not Injected";
                }
                else if (APIType.Text == "ApiModule")
                {
                    if (ApiModule.ApiModule.namedPipeExist("462B9C47BB16AF43C5CF0BB7C970349DCEA20D1BFB8AA87E688BAF8E93553B0F"))
                        StatusTxt.Text = "Status: Injected";
                    else
                        StatusTxt.Text = "Status: Not Injected";
                }
                else if (APIType.Text == "SirHurtAPI")
                {
                    if (SirHurtAPI.SirHurtAPI.isInjected())
                        StatusTxt.Text = "Status: Injected";
                    else
                        StatusTxt.Text = "Status: Not Injected";
                }
                else if (APIType.Text == "Krnl")
                {
                    if (KrnlAPI.isKrnlInjected())
                        StatusTxt.Text = "Status: Injected";
                    else
                        StatusTxt.Text = "Status: Not Injected";
                }
                else
                    StatusTxt.Text = "Status: Not Injected";
            }
            else
                StatusTxt.Text = "Status: Not Injected";
        }

        private void AutoHook_CheckedChanged(object sender, EventArgs e)
        {
            var a = Registry.CurrentUser.CreateSubKey("ZeroTsuSploit");
            a.SetValue("AutoHook", AutoHook.Checked);
            if (AutoHook.Checked)
            {
                TimeBfITxt.Visible = true;
                WaitInjectTime.Visible = true;
                Hooker.Start();
            }
            else
            {
                Hooker.Stop();
                TimeBfITxt.Visible = false;
                WaitInjectTime.Visible = false;
            }
        }

        private void ListBox_DoubleClick(object sender, EventArgs e)
        {
            if (ListBox.SelectedItem.ToString().Contains(".txt") || ListBox.SelectedItem.ToString().Contains(".lua"))
            {
                try
                {
                    var Script = File.ReadAllText(DefaultDir + @"\" + ListBox.SelectedItem.ToString());
                    BestTextBox.Text = Script;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed to Read file " + ListBox.SelectedItem.ToString() + "\nLogs:\n" + ex);
                    MessageBox.Show("Failed to Read file " + ListBox.SelectedItem.ToString() + "\nLogs:\n" + ex, "TsuSploit");
                }
            }
        }

        private void ReLoad_Click(object sender, EventArgs e)
        {
            ListBoxInit();
        }

        private void ChangePath_Click(object sender, EventArgs e)
        {
            var a = FolderSetter.ShowDialog();
            if (a == DialogResult.OK)
            {
                DefaultDir = FolderSetter.SelectedPath;
                ScriptPath.Text = DefaultDir;
                var b = Registry.CurrentUser.CreateSubKey("ZeroTsuSploit");
                b.SetValue("DefaultDir", DefaultDir);
                ListBoxInit();
            }
        }

        private void ResetDir_Click(object sender, EventArgs e)
        {
            DefaultDir = AppDomain.CurrentDomain.BaseDirectory + "Scripts";
            ScriptPath.Text = DefaultDir;
            var a = Registry.CurrentUser.CreateSubKey("ZeroTsuSploit");
            a.SetValue("DefaultDir", DefaultDir);
            ListBoxInit();
        }

        private void OpenScript_Click(object sender, EventArgs e)
        {
            ScriptOpener.FileName = "";
            var a = ScriptOpener.ShowDialog();
            if (a == DialogResult.OK)
            {
                try
                {
                    BestTextBox.Text = File.ReadAllText(ScriptOpener.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to read file " + ScriptOpener.FileName + "\nLogs:\n" + ex);
                }
            }
        }

        private void SaveScript_Click(object sender, EventArgs e)
        {
            SaveScripts.FileName = "";
            var a = SaveScripts.ShowDialog();
            if (a == DialogResult.OK)
            {
                try
                {
                    if (File.Exists(SaveScripts.FileName))
                    {
                        File.Delete(SaveScripts.FileName);
                    }
                    using (FileStream fs = File.Create(SaveScripts.FileName))
                    {
                        Byte[] title = new UTF8Encoding(true).GetBytes(BestTextBox.Text);
                        fs.Write(title, 0, title.Length);
                    }
                    ListBoxInit();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to write file " + SaveScripts.FileName + "\nLogs:\n" + ex);
                }
            }
        }

        private void DlLatestVer_Click(object sender, EventArgs e)
        {
            try
            {
                ServicePointManager.ServerCertificateValidationCallback += new RemoteCertificateValidationCallback(AlwaysGoodCertificate);
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                using (WebClient wc = new WebClient())
                {
                    wc.DownloadFileCompleted += Wc_DownloadFileCompleted;
                    wc.DownloadFileAsync(new Uri("https://raw.githubusercontent.com/teppyboy/TsuSploit/master/Updater/bin/Debug/Updater.exe"), "Updater.exe");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to download Updater.exe");
                Console.WriteLine("Log: " + ex);
                MessageBox.Show("Failed to download Updater.exe\nLog:\n" + ex);
            }
        }

        private void Wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            ProcessStartInfo p = new ProcessStartInfo();
            p.FileName = "Updater.exe";
            p.Arguments = "-baseApp." + Process.GetCurrentProcess().MainModule.FileName + " -fromUrl.https://raw.githubusercontent.com/teppyboy/TsuSploit/master/TsuSploit/bin/Debug/TsuSploit.exe -relaunch";
            Process.Start(p);
        }

        private void WaitInjectTime_TextChanged(object sender, EventArgs e)
        {
            var sucess = int.TryParse(WaitInjectTime.Text, out WaitBeforeInject);
            if (!sucess && (WaitInjectTime.Text == ""))
            {
                WaitBeforeInject = 10;
                WaitInjectTime.Text = "10";
                MessageBox.Show("Not a vaild Integer value.", "TsuSploit");
            }
            var a = Registry.CurrentUser.CreateSubKey("ZeroTsuSploit");
            a.SetValue("AutoHookDelay", WaitBeforeInject);
        }
        private void SilentInject()
        {
            StatusTxt.Text = "Status: Injecting";
            isInjecting = true;
            Process[] pname = Process.GetProcessesByName("RobloxPlayerBeta");
            if (pname.Length != 0)
            {
                if (APIType.Text == "WeAreDevs API")
                {
                    if (ExploitAPI.isAPIAttached())
                        Console.WriteLine("Already Injected WeAreDevs API");
                    else if (ExploitAPI.IsUpdated())
                    {
                        if (ExploitAPI.DownloadLatestVersion())
                        {
                            foreach (var rbx in Process.GetProcessesByName("RobloxPlayerBeta"))
                            {
                                var injector = new Injector(rbx);
                                if (injector.Inject(AppDomain.CurrentDomain.BaseDirectory + "exploit-main.dll") != 0)
                                    Console.WriteLine("Injected WeAreDevs API");
                                else
                                    Console.WriteLine("Failed to inject WeAreDevs API");
                                injector.Dispose();
                                isInjecting = false;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Failed to download exploit-main.dll");
                        }
                    }
                    else if (!ExploitAPI.isAPIAttached())
                    {
                        Console.WriteLine("WeAreDevs API is currently patched... Please wait for the developers to fix it! Meanwhile, check wearedevs.net for updates/info.");
                    }
                }
                else if (APIType.Text == "EasyExploits API")
                {
                    if (Module.namedPipeExist("ocybedam"))
                    {
                        Console.WriteLine("Already Injected EasyExploit API");
                        return;
                    }
                    if (!File.Exists("EasyExploitsDLL.dll"))
                    {
                        if (!Module.DownloadDLL())
                        {
                            Console.WriteLine("Failed to download EasyExploitsDLL.dll");
                            isInjecting = false;
                            return;
                        }
                    }
                    try
                    {
                        foreach (var rbx in Process.GetProcessesByName("RobloxPlayerBeta"))
                        {
                            var injector = new Injector(rbx);
                            if (injector.Inject(AppDomain.CurrentDomain.BaseDirectory + "EasyExploitsDLL.dll") != 0)
                                Console.WriteLine("Injected EasyExploits API");
                            else
                                Console.WriteLine("Failed to inject EasyExploits API");
                            injector.Dispose();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Failed to inject EasyExploits API [T/C].");
                        Console.WriteLine(ex);
                        isInjecting = false;
                    }
                }
                else if (APIType.Text == "ApiModule")
                {
                    if (ApiModule.ApiModule.namedPipeExist("462B9C47BB16AF43C5CF0BB7C970349DCEA20D1BFB8AA87E688BAF8E93553B0F"))
                    {
                        Console.WriteLine("Already Injected ApiModule");
                        isInjecting = false;
                        return;
                    }
                    if (!File.Exists("ApiModuleDLL.dll"))
                    {
                        if (!ApiModule.ApiModule.DownloadDLL())
                        {
                            Console.WriteLine("Failed to download ApiModuleDLL.dll");
                            isInjecting = false;
                            return;
                        }
                    }
                    try
                    {
                        foreach (var rbx in Process.GetProcessesByName("RobloxPlayerBeta"))
                        {
                            var injector = new Injector(rbx);
                            if (injector.Inject(AppDomain.CurrentDomain.BaseDirectory + "ApiModuleDLL.dll") != 0)
                                Console.WriteLine("Injected ApiModule");
                            else
                                Console.WriteLine("Failed to inject ApiModule");
                            injector.Dispose();
                            isInjecting = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Failed to inject ApiModule [T/C].");
                        Console.WriteLine(ex);
                        isInjecting = false;
                    }
                }
                else if (APIType.Text == "SirHurtAPI")
                {
                    if (SirHurtAPI.SirHurtAPI.isInjected())
                    {
                        Console.WriteLine("Already injected SirHurtAPI.");
                        isInjecting = false;
                        return;
                    }
                    else if (!SirHurtAPI.SirHurtAPI.DownloadDll(false))
                    {
                        Console.WriteLine("Failed to download SirHurt.dll");
                        isInjecting = false;
                        return;
                    }
                    foreach (var rbx in Process.GetProcessesByName("RobloxPlayerBeta"))
                    {
                        try
                        {
                            var injector = new Injector(rbx);
                            if (injector.Inject(AppDomain.CurrentDomain.BaseDirectory + "SirHurt.dll") != 0)
                            {
                                Console.WriteLine("Injected SirHurtAPI.");
                            }
                            else
                            {
                                Console.WriteLine("Failed to inject SirHurtAPI");
                            }
                            injector.Dispose();
                            isInjecting = false;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Failed to inject SirHurtAPI [T/C].");
                            Console.WriteLine(ex);
                            isInjecting = false;
                        }
                    }
                }
                else if (APIType.Text == "Krnl")
                {
                    foreach (var rbx in Process.GetProcessesByName("RobloxPlayerBeta"))
                    {
                        try
                        {
                            var injector = new Injector(rbx);
                            if ((injector.Inject(AppDomain.CurrentDomain.BaseDirectory + "krnl2.dll") != 0) && (injector.Inject(AppDomain.CurrentDomain.BaseDirectory + "Indicium-Supra.dll") != 0))
                            {
                                Console.WriteLine("Injected SirHurtAPI.");
                                //MessageBox.Show("Injected SirHurtAPI", "TsuSploit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                Console.WriteLine("Failed to inject SirHurtAPI");
                                //MessageBox.Show("Failed to inject SirHurtAPI", "TsuSploit", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            injector.Dispose();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Failed to inject Krnl [T/C].");
                            Console.WriteLine(ex);
                        }
                    }
                }
                else
                    Console.WriteLine("No API selected.");
                }
                else
                    Console.WriteLine("ROBLOX is not running.");
                isInjecting = false;
            }
            private void Hooker_Tick(object sender, EventArgs e)
            {
                Process[] pname = Process.GetProcessesByName("RobloxPlayerBeta");
                if (pname.Length != 0 && !isInjecting)
                {
                    if (APIType.Text == "WeAreDevs API")
                    {
                        if (!ExploitAPI.isAPIAttached())
                        {
                            WaitInjectTime.Enabled = false;
                            if (Waiter < (WaitBeforeInject * 10))
                            {
                                Console.WriteLine("Waiting (milisecond*100):" + Waiter.ToString());
                                Waiter++;
                            }
                            else
                            {
                                Console.WriteLine("Waited complete, Injecting...");
                                SilentInject();
                                Console.WriteLine("Reseted waiter to 0");
                                Waiter = 0; // Reset waiter to 0
                            }
                        }
                        else
                        {
                            Waiter = 0; // Reset waiter to 0
                            WaitInjectTime.Enabled = true;
                        }
                    }
                    else if (APIType.Text == "EasyExploits API")
                    {
                        if (!Module.namedPipeExist("ocybedam"))
                        {
                            WaitInjectTime.Enabled = false;
                            if (Waiter < (WaitBeforeInject * 10))
                            {
                                Console.WriteLine("Waiting (milisecond*100):" + Waiter.ToString());
                                Waiter++;
                            }
                            else
                            {
                                Console.WriteLine("Waited complete, Injecting...");
                                SilentInject();
                                Console.WriteLine("Reseted waiter to 0");
                                Waiter = 0; // Reset waiter to 0
                            }
                        }
                        else
                        {
                            Waiter = 0; // Reset waiter to 0
                            WaitInjectTime.Enabled = true;
                        }
                    }
                    else if (APIType.Text == "ApiModule")
                    {
                        if (!ApiModule.ApiModule.namedPipeExist("462B9C47BB16AF43C5CF0BB7C970349DCEA20D1BFB8AA87E688BAF8E93553B0F"))
                        {
                            WaitInjectTime.Enabled = false;
                            if (Waiter < (WaitBeforeInject * 10))
                            {
                                Console.WriteLine("Waiting (milisecond*100):" + Waiter.ToString());
                                Waiter++;
                            }
                            else
                            {
                                Console.WriteLine("Waited complete, Injecting...");
                                SilentInject();
                                Console.WriteLine("Reseted waiter to 0");
                                Waiter = 0; // Reset waiter to 0
                            }
                        }
                        else
                        {
                            Waiter = 0; // Reset waiter to 0
                            WaitInjectTime.Enabled = true;
                        }
                    }
                else if (APIType.Text == "Krnl")
                {
                    if (!KrnlAPI.isKrnlInjected())
                    {
                        WaitInjectTime.Enabled = false;
                        if (Waiter < (WaitBeforeInject * 10))
                        {
                            Console.WriteLine("Waiting (milisecond*100):" + Waiter.ToString());
                            Waiter++;
                        }
                        else
                        {
                            Console.WriteLine("Waited complete, Injecting...");
                            SilentInject();
                            Console.WriteLine("Reseted waiter to 0");
                            Waiter = 0; // Reset waiter to 0
                        }
                    }
                    else
                    {
                        Waiter = 0; // Reset waiter to 0
                        WaitInjectTime.Enabled = true;
                    }
                }
            }
            }

            private void TopMostCheck_CheckedChanged(object sender, EventArgs e)
            {
                var a = Registry.CurrentUser.CreateSubKey("ZeroTsuSploit");
                a.SetValue("TopMost", TopMostCheck.Checked);
            }

            private void APIType_SelectedIndexChanged(object sender, EventArgs e)
            {
                var a = Registry.CurrentUser.CreateSubKey("ZeroTsuSploit");
                a.SetValue("ApiMode", APIType.Text);
            }

            private void HoverOp_Tick(object sender, EventArgs e)
            {
                if (!MouseIsOverControl(this) && (!isMinimizing && !isExiting && !isStarting))
                {
                    if (this.Opacity > .20)
                    {
                        isHoverOp = true;
                        Opacity -= .05;
                    }
                    else
                        isHoverOp = false;
                }
                else if (!isMinimizing && !isExiting && !isStarting)
                {
                    if (this.Opacity < 1 && this.Opacity >= .19)
                    {
                        isHoverOp = true;
                        Opacity += .05;
                    }
                    else
                        isHoverOp = false;
                }
            }
            private void FocusCheck_Tick(object sender, EventArgs e)
            {
                if (!ApplicationIsActivated() && (!isMinimizing && !isExiting && !isHoverOp && !TopMostCheck.Checked && !isStarting))
                {
                    if (this.Opacity > 0)
                    {
                        Opacity -= .05;
                    }
                    else
                        WindowState = FormWindowState.Minimized;
                }
                else if (!isMinimizing && !isExiting && !isHoverOp && !isStarting)
                {
                    if (!isHoverOpE)
                    {
                        if (this.Opacity < 1)
                            Opacity += .05;
                    }
                    else
                    {
                        if (this.Opacity < .19)
                            Opacity += .05;
                    }
                }
            }
        }
    }