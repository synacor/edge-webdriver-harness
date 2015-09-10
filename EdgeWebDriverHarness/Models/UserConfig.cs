using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace EdgeWebDriverHarness.Models {

    sealed class UserConfig {
        static readonly Lazy<UserConfig> _lazy = new Lazy<UserConfig>(() => new UserConfig());

        public List<Page> Pages { get; set; } = new List<Page> { new Page { Name = "Root", Suffix = "/" } };
        public List<Site> Sites { get; set; } = new List<Site> { new Site { BaseUrl = "http://bing.com", Name = "Bing", Cluster = "Cloud" } };
        public string ErrorLog { get; set; } = string.Empty;
        public string ScreenShotPath { get; set; } = string.Empty;

        UserConfig() {
        }

        public void Reload() {
            if (!File.Exists(Properties.Settings.Default.ConfigFileName)) {
                Trace.WriteLine($"No {Properties.Settings.Default.ConfigFileName} found, default file created.");
                Trace.WriteLine($"Please customize {Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Properties.Settings.Default.ConfigFileName)}");
                File.WriteAllText(Properties.Settings.Default.ConfigFileName, JsonConvert.SerializeObject(Instance, Formatting.Indented));
            } else {
                Pages = null;
                Sites = null;
                var settings = File.ReadAllText(Properties.Settings.Default.ConfigFileName);
                JsonConvert.PopulateObject(settings, Instance);
            }
        }

        public static UserConfig Instance { get { return _lazy.Value; } }
    }
}