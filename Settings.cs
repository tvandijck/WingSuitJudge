using System.Drawing;
using Microsoft.Win32;

namespace WingSuitJudge
{
    public class Settings
    {
        public bool ShowLines { get; set; }
        public bool ShowMarkers { get; set; }
        public bool ShowWingsuits { get; set; }
        public bool ShowPhoto { get; set; }
        public bool ShowFlightZones { get; set; }
        public int AngleTolerance { get; set; }
        public int DistanceTolerance { get; set; }
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
            Registry.SetValue("HKEY_CURRENT_USER\\Software\\WingsuitJudge", "AngleTolerance", AngleTolerance, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_CURRENT_USER\\Software\\WingsuitJudge", "DistanceTolerance", DistanceTolerance, RegistryValueKind.DWord);
            Registry.SetValue("HKEY_CURRENT_USER\\Software\\WingsuitJudge", "BaseLineColor", BaseLineColor.ToArgb(), RegistryValueKind.DWord);
        }

        public void Load()
        {
            ShowLines = (int)Registry.GetValue("HKEY_CURRENT_USER\\Software\\WingsuitJudge", "ShowLines", 1) == 1;
            ShowMarkers = (int)Registry.GetValue("HKEY_CURRENT_USER\\Software\\WingsuitJudge", "ShowMarkers", 1) == 1;
            ShowWingsuits = (int)Registry.GetValue("HKEY_CURRENT_USER\\Software\\WingsuitJudge", "ShowWingsuits", 0) == 1;
            ShowPhoto = (int)Registry.GetValue("HKEY_CURRENT_USER\\Software\\WingsuitJudge", "ShowPhoto", 1) == 1;
            ShowFlightZones = (int)Registry.GetValue("HKEY_CURRENT_USER\\Software\\WingsuitJudge", "ShowFlightZones", 1) == 1;
            AngleTolerance = (int)Registry.GetValue("HKEY_CURRENT_USER\\Software\\WingsuitJudge", "AngleTolerance", 18);
            DistanceTolerance = (int)Registry.GetValue("HKEY_CURRENT_USER\\Software\\WingsuitJudge", "DistanceTolerance", 35);
            BaseLineColor = Color.FromArgb((int)Registry.GetValue("HKEY_CURRENT_USER\\Software\\WingsuitJudge", "BaseLineColor", Color.Blue.ToArgb()));
        }
    }
}
