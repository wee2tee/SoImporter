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
        public int Lines { get; set; }

        public static ConfigValue Load()
        {
            string cfg_file = AppDomain.CurrentDomain.BaseDirectory + "setting.cfg";

            if (!File.Exists(cfg_file))
            {
                return new ConfigValue()
                {
                    ExpressDataPath = string.Empty,
                    Lines = 0
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

                                if (line.Contains("LINES:"))
                                {
                                    cfg.Lines = Convert.ToInt32(line.Replace("LINES:", "").Replace("|", "").Trim());
                                    continue;
                                }
                            }
                            sr.Close();
                        }
                        fs.Close();
                    }

                    return cfg;
                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.Message);
                    return new ConfigValue()
                    {
                        ExpressDataPath = string.Empty,
                        Lines = 0
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
                        sw.WriteLine("LINES: | " + this.Lines);
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
