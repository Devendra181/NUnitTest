using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace TestNinja.Mocking
{
    public class VideoService
    {

        //Property injection

        //public IFileReader FileReader { get; set; }

        //public VideoService()
        //{
        //    FileReader = new FileReader();
        //}


        //Constructor injection
        private readonly IFileReader _fileReader;

        //For Production code
        public VideoService()
        {
            _fileReader = new FileReader();
        }

        //For Test code
        public VideoService(IFileReader fileReader)
        {
            _fileReader = fileReader;
        }


        //Or Combined injection  works but not ideal, Poor man's DI
        //public VideoService(IFileReader fileReader = null)
        //{
        //    _fileReader = fileReader ?? new FileReader();
        //}

        public string ReadVideoTitle()  //ReadVideoTitle(IFileReader fileReader) Method injection
        {
            var str = _fileReader.Read("video.txt");
            var video = JsonConvert.DeserializeObject<Video>(str);
            if (video == null)
                return "Error parsing the video.";
            return video.Title;
        }

        public string GetUnprocessedVideosAsCsv()
        {
            var videoIds = new List<int>();
            
            using (var context = new VideoContext())
            {
                var videos = 
                    (from video in context.Videos
                    where !video.IsProcessed
                    select video).ToList();
                
                foreach (var v in videos)
                    videoIds.Add(v.Id);

                return String.Join(",", videoIds);
            }
        }
    }

    public class Video
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsProcessed { get; set; }
    }

    public class VideoContext : DbContext
    {
        public DbSet<Video> Videos { get; set; }
    }
}