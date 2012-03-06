using System.Drawing;
using Microsoft.Win32;

namespace Flock
{
    public class Settings
    {
        public bool ShowLines { get; set; }
        public bool ShowMarkers { get; set; }
        public bool ShowWingsuits { get; set; }
        public bool ShowPhoto { get; set; }
        public bool ShowFlightZones { get; set; }
        public bool ShowDots { get; set; }
        public bool ShowGrid { get; set; }
        public int AngleTolerance { get; set; }
        public int DistanceTolerance { get; set; }
        public int WingsuitSize { get; set; }
        public int DotCount { get; set; }
        public int DotSize { get; set; }
        public int DotDistance { get; set; }
        public int DotStretch { get; set; }
        public int DotRotate { get; set; }
        public int GridCount { get; set; }
        public int GridSize { get; set; }
        public float GridRotate { get; set; }
        public Color BaseLineColor { get; set; }

        private static Settings defaultInstance = new Settings();

        public static Settings Default
        {
            get { return defaultInstance; }
        }

        public Settings()
        {
            Load();
        }

        public void Save()
        {
            Registry.SetValue("HKEY_CURRENT_USER\\Software\\WingsuitJudge", "ShowLines", ShowLines, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_CURRENT_USER\\Software\\WingsuitJudge", "ShowMarkers", ShowMarkers, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_CURRENT_USER\\Software\\WingsuitJudge", "ShowWingsuits", ShowWingsuits, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_CURRENT_USER\\Software\\WingsuitJudge", "ShowPhoto", ShowPhoto, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_CURRENT_USER\\Software\\WingsuitJudge", "ShowFlightZones", ShowFlightZones, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_CURRENT_USER\\Software\\WingsuitJudge", "ShowDots", ShowDots, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_CURRENT_USER\\Software\\WingsuitJudge", "ShowGrid", ShowGrid, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_CURRENT_USER\\Software\\WingsuitJudge", "AngleTolerance", AngleTolerance, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_CURRENT_USER\\Software\\WingsuitJudge", "DistanceTolerance", DistanceTolerance, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_CURRENT_USER\\Software\\WingsuitJudge", "BaseLineColor", BaseLineColor.ToArgb(), RegistryValueKind.DWord);
            Registry.SetValue("HKEY_CURRENT_USER\\Software\\WingsuitJudge", "WingsuitSize", WingsuitSize, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_CURRENT_USER\\Software\\WingsuitJudge", "DotCount", DotCount, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_CURRENT_USER\\Software\\WingsuitJudge", "DotSize", DotSize, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_CURRENT_USER\\Software\\WingsuitJudge", "DotDistance", DotDistance, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_CURRENT_USER\\Software\\WingsuitJudge", "DotStretch", DotStretch, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_CURRENT_USER\\Software\\WingsuitJudge", "DotRotate", DotRotate, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_CURRENT_USER\\Software\\WingsuitJudge", "GridCount", GridCount, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_CURRENT_USER\\Software\\WingsuitJudge", "GridSize", GridSize, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_CURRENT_USER\\Software\\WingsuitJudge", "GridRotate", GridRotate, RegistryValueKind.DWord);
        }

        public void Load()
        {
            ShowLines = GetValue("HKEY_CURRENT_USER\\Software\\WingsuitJudge", "ShowLines", true);
            ShowMarkers = GetValue("HKEY_CURRENT_USER\\Software\\WingsuitJudge", "ShowMarkers", true);
            ShowWingsuits = GetValue("HKEY_CURRENT_USER\\Software\\WingsuitJudge", "ShowWingsuits", false);
            ShowPhoto = GetValue("HKEY_CURRENT_USER\\Software\\WingsuitJudge", "ShowPhoto", true);
            ShowFlightZones = GetValue("HKEY_CURRENT_USER\\Software\\WingsuitJudge", "ShowFlightZones", true);
            ShowDots = GetValue("HKEY_CURRENT_USER\\Software\\WingsuitJudge", "ShowDots", true);
            ShowGrid = GetValue("HKEY_CURRENT_USER\\Software\\WingsuitJudge", "ShowGrid", true);
            AngleTolerance = GetValue("HKEY_CURRENT_USER\\Software\\WingsuitJudge", "AngleTolerance", 18);
            DistanceTolerance = GetValue("HKEY_CURRENT_USER\\Software\\WingsuitJudge", "DistanceTolerance", 35);
            WingsuitSize = GetValue("HKEY_CURRENT_USER\\Software\\WingsuitJudge", "WingsuitSize", 100);
            BaseLineColor = GetValue("HKEY_CURRENT_USER\\Software\\WingsuitJudge", "BaseLineColor", Color.Blue);
            DotCount = GetValue("HKEY_CURRENT_USER\\Software\\WingsuitJudge", "DotCount", 3);
            DotSize = GetValue("HKEY_CURRENT_USER\\Software\\WingsuitJudge", "DotSize", 80);
            DotDistance = GetValue("HKEY_CURRENT_USER\\Software\\WingsuitJudge", "DotDistance", 250);
            DotStretch = GetValue("HKEY_CURRENT_USER\\Software\\WingsuitJudge", "DotStretch", 100);
            DotRotate = GetValue("HKEY_CURRENT_USER\\Software\\WingsuitJudge", "DotRotate", 0);
            GridCount = GetValue("HKEY_CURRENT_USER\\Software\\WingsuitJudge", "GridCount", 3);
            GridSize = GetValue("HKEY_CURRENT_USER\\Software\\WingsuitJudge", "GridSize", 100);
            GridRotate = GetValue("HKEY_CURRENT_USER\\Software\\WingsuitJudge", "GridRotate", 0);
        }

        static bool GetValue(string location, string key, bool def)
        {
            object value = Registry.GetValue(location, key, def ? 1 : 0);
            if (value == null)
            {
                return def;
            }
            return (int)value == 1;
        }


        static int GetValue(string location, string key, int def)
        {
            object value = Registry.GetValue(location, key, def);
            if (value == null)
            {
                return def;
            }
            return (int)value;
        }

        static Color GetValue(string location, string key, Color def)
        {
            object value = Registry.GetValue(location, key, def.ToArgb());
            if (value == null)
            {
                return def;
            }
            return Color.FromArgb((int)value);
        }
    }
}
