using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SoImporter.MiscClass
{
    public class ConfigValue
    {
        public string ExpressDataPath { get; set; }
        public string DocPrefix { get; set; }
        public string ApiUrl { get; set; }
        public string ApiKey { get; set; }
        public string SaltKey { get; set; }
        private const string salt_key = "esg022173533";

        public static ConfigValue Load()
        {
            string cfg_file = AppDomain.CurrentDomain.BaseDirectory + "setting.cfg";

            if (!File.Exists(cfg_file))
            {
                return new ConfigValue()
                {
                    ExpressDataPath = string.Empty,
                    DocPrefix = string.Empty,
                    ApiUrl = string.Empty,
                    ApiKey = string.Empty,
                    SaltKey = salt_key 
                };
            }
            else
            {
                ConfigValue cfg = new ConfigValue();
                try
                {
                    using (FileStream fs = new FileStream(cfg_file, FileMode.Open, FileAccess.Read))
                    {
                        using (StreamReader sr = new StreamReader(fs, Encoding.GetEncoding("utf-8")))
                        {
                            string line;
                            while ((line = sr.ReadLine()) != null)
                            {
                                if (line.Contains("EXPRESS_DATA_PATH:"))
                                {
                                    cfg.ExpressDataPath = line.Replace("EXPRESS_DATA_PATH:", "").Replace("|", "").Trim();
                                    continue;
                                }

                                if (line.Contains("DOC_PREFIX:"))
                                {
                                    cfg.DocPrefix = line.Replace("DOC_PREFIX:", "").Replace("|", "").Trim();
                                    continue;
                                }

                                if (line.Contains("API_URL:"))
                                {
                                    cfg.ApiUrl = line.Replace("API_URL:", "").Replace("|", "").Trim();
                                    continue;
                                }

                                if (line.Contains("API_KEY:"))
                                {
                                    cfg.ApiKey = line.Replace("API_KEY:", "").Replace("|", "").Trim();
                                    continue;
                                }
                            }
                            sr.Close();
                        }
                        fs.Close();
                    }

                    cfg.SaltKey = salt_key;
                    return cfg;
                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.Message);
                    return new ConfigValue()
                    {
                        ExpressDataPath = string.Empty,
                        DocPrefix = string.Empty,
                        ApiUrl = string.Empty,
                        ApiKey = string.Empty,
                        SaltKey = salt_key
                    };
                }
            }
        }

        public ConfigValue Save()
        {
            string cfg_file = AppDomain.CurrentDomain.BaseDirectory + "setting.cfg";

            try
            {
                using (FileStream fs = new FileStream(cfg_file, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    fs.Close();

                    using (StreamWriter sw = new StreamWriter(cfg_file, false, Encoding.GetEncoding("utf-8")))
                    {
                        sw.WriteLine("EXPRESS_DATA_PATH: | " + this.ExpressDataPath);
                        sw.WriteLine("DOC_PREFIX: | " + this.DocPrefix);
                        sw.WriteLine("API_URL: | " + this.ApiUrl);
                        sw.WriteLine("API_KEY: | " + this.ApiKey);
                        sw.Close();
                    }
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message);
            }

            return Load();
        }
    }
}
