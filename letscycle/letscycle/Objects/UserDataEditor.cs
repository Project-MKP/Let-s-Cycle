using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace letscycle
{
    public class UserDataEditor
    {
        public UserDataEditor()
        {

        }

        public void SaveTracksToFile(List<Track> tracks)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string filename = Path.Combine(path, "userdata.txt");

            using (var streamWriter = new StreamWriter(filename, true))
            {
                foreach (Track track in tracks)
                {
                    streamWriter.WriteLine("{0}|{1}|{2}", track.imgPath, track.street, track.bikersToday);
                }
            }
        }

        public List<Track> ReadUserData(List<Track> list)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string filename = Path.Combine(path, "userdata.txt");

            if (File.Exists(filename))
            {
                using (var streamReader = new StreamReader(filename))
                {
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        string[] element = line.Split('|');

                        Track track = new Track() { imgPath = element[0], street = element[1], bikersToday = element[2] };
                        if(!list.Contains(track))
                        {
                            list.Add(track);
                        } 
                    }
                }
            }
            return list;
        }

        public List<Track> RemoveTrack(Track selectedTrack, List<Track> list)
        {
            list.Remove(selectedTrack);

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string filename = Path.Combine(path, "userdata.txt");

            using (FileStream fs = new FileStream(filename, FileMode.Truncate)) { }

            SaveTracksToFile(list);
            return list;
        }

        public void ClearFile()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string filename = Path.Combine(path, "userdata.txt");
            using (FileStream fs = new FileStream(filename, FileMode.Truncate)) { }
        }
    }
}
