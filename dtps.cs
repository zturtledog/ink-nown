//# puropse : to facilitate dtps comunication
//# author : confusedParrotfish
//# exclude all comment formating, or just don't read this code

// package net.twallowhavenstudios.extraAdditions;

// import java.io.File;
// import java.io.IOException;
// import java.util.ArrayList;
// import java.util.Scanner;

//    \n +\{

using System.Collections;
using System;
using System.Security.Cryptography;
using System.IO;
using System.Text;

namespace ink_nown {
    public class dtps {
        public ArrayList sectionData = new ArrayList();
        public ArrayList vars = new ArrayList();
        public string f_dat = "";

        private secdar sec;

        //forms of load / entrypoint

        public dtps load(string file) {
            return (txt(System.IO.File.ReadAllText(@file)));
        }
        public dtps loadEncrypted(string crkey, string file) {
            return (txt(cryptography.DecryptString(crkey, System.IO.File.ReadAllText(@file))));
        }
        public dtps txtEncrypted(string crkey, string file) {
            return (txt(cryptography.DecryptString(crkey, file)));
        }
        public dtps txt(string file) {
            string[] lines = file.Split('\n');
            ArrayList infos = new ArrayList();
            string segment = "";

            for (int i = 0; i < lines.Length; i++) {
                string current = lines[i].Replace(" ", "");

                if (current.Contains(":")) {
                    if (current.StartsWith(":")) {
                        if (segment != "null") {
                            sectionData.Add(new secdar(segment, infos));
                            infos.Clear();
                        }
                        segment = current;
                    }
                    else if (current.StartsWith(".")) {
                        vars.Add(new varible(current.Replace(".", "").Split(':')[0], AddFormat(current.Split(':')[1])));
                    }
                    else {
                        infos.Add(current);
                    }
                }
            }
            sectionData.Add(new secdar(segment, infos));
            infos.Clear();

            return this;
        }

        //get

        public string getRaw(string path) {
            foreach (secdar data in sectionData) {
                if (numerate(data.secname) == numerate(path.Split('.')[0])) {
                    foreach (string line in data.infos) {
                        if (numerate(line.Split(':')[0]) == numerate(path.Split('.')[1])) {
                            return (AddFormat(line.Split(':')[1]));
                        }
                    }
                }
            }

            return ("");// ("dataline not found!");
        }
        public double getNum(string path) {
            string got = getRaw(path);
            return (double.Parse(got));
        }
        public bool getBool(string path) {
            string got = getRaw(path);
            return (got == "true" ? true : false);
        }
        public ArrayList getHeadAsArray(string head) {
            ArrayList end = new ArrayList();
            foreach (secdar data in sectionData) {
                if (numerate(data.secname) == numerate(head)) {
                    foreach (string line in data.infos) {
                        end.Add(new idra(line.Split(':')[0], AddFormat(line.Split(':')[1])));
                    }
                }
            }
            return (end);
        }

        //helperss

        private string AddFormat(string s) {
            return (variate(s.Replace("/~", "Ξ").Replace("~", " ").Replace('Ξ', '~').Replace("~ ~", "")));
        }

        private string variate(string input) {
            foreach (varible var in vars) {
                // System.out.println("x");
                input = input.Replace(var.name, var.value);
            }

            return (input);
        }

        static string join(string[] Split, string d) {
            string end = "";

            for (int i = 0; i < Split.Length; i++) {
                end += Split[i] + d;
            }

            return (end);
        }

        private static int numerate(string ix) {
            int end = 0;
            for (int i = 0; i < ix.Length; i++) {
                end += ix.ToCharArray()[i] * (10 ^ i);
            }
            return (end);
        }

        //subclasses

        public class idra {
            public string name;
            public string value;

            public idra(string n, string v) {
                name = n;
                value = v;
            }
        }

        public class secdar {
            public string secname;
            public ArrayList infos;

            public secdar(string name, ArrayList data) {
                secname = name;
                infos = (ArrayList)data.Clone();
            }
        }

        public class varible {
            public string name = "";
            public string value = "";

            public varible(string nme, string vlu) {
                name = nme;
                value = vlu;
            }
        }

        //compile

        public void startSection(string section) {
            sec = new secdar(section, new ArrayList());
        }
        public void insert(string nyble, object item) {
            sec.infos.Add(nyble + ": " + (string)item);
        }
        public void endSection() {
            sectionData.Add(sec);
            sec = null;
        }
        public void addSectionArray(string name, string[] data) {
            ArrayList end = new ArrayList();
            int i = 0;
            foreach (String thing in data) {
                i++;
                end.Add(i + ": " + thing);
            }
            sectionData.Add(new secdar(name, end));
        }
        public void addVarible(string name, object value) {
            vars.Add(new varible(name, (string)value));
        }
        public String compile() {
            String end = "";

            for (int i = 0; i < vars.Count; i++) {
                end += "." + ((varible)vars[i]).name + " : " + ((varible)vars[i]).value + "\n";
            }
            for (int i = 0; i < sectionData.Count; i++) {
                secdar current = ((secdar)sectionData[i]);

                end += "\n" + current.secname + "\n";

                for (int j = 0; j < current.infos.Count; j++) {
                    end += "    " + current.infos[j] + "\n";
                }
            }

            return end;
        }
        public string compileAndEncrypt(string crkey) {
            return cryptography.EncryptString(crkey, compile());
        }

        //cryptography

        public class cryptography {
            public static string EncryptString(string crkey, string plainInput) {
                byte[] iv = new byte[16];
                byte[] array;
                using (Aes aes = Aes.Create()) {
                    aes.Key = Encoding.UTF8.GetBytes(crkey);
                    aes.IV = iv;
                    ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                    using (MemoryStream memoryStream = new MemoryStream()) {
                        using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write)) {
                            using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream)) {
                                streamWriter.Write(plainInput);
                            }

                            array = memoryStream.ToArray();
                        }
                    }
                }

                return Convert.ToBase64String(array);
            }

            public static string DecryptString(string crkey, string cipherText) {
                byte[] iv = new byte[16];
                byte[] buffer = Convert.FromBase64String(cipherText);
                using (Aes aes = Aes.Create()) {
                    aes.Key = Encoding.UTF8.GetBytes(crkey);
                    aes.IV = iv;
                    ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
                    using (MemoryStream memoryStream = new MemoryStream(buffer)) {
                        using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read)) {
                            using (StreamReader streamReader = new StreamReader((Stream)cryptoStream)) {
                                return streamReader.ReadToEnd();
                            }
                        }
                    }
                }
            }
        }
    }
}