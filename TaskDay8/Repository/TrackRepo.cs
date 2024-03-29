using Microsoft.AspNetCore.Http.HttpResults;
using TaskDay8.Models;

namespace TaskDay8.Repository
{
    public class TrackRepo : ITrackRepo
    {
        public readonly AppDbContext context;
        public TrackRepo(AppDbContext context)
        {
            this.context = context;
        }
        public void Create(Track track)
        {
            if(track != null) 
            {
             context.tracks.Add(track);
             context.SaveChanges();
            }
            
        }

        public void DeleteById(int id)
        {
            var track = context.tracks.Find(id);
            if (track != null)
            {
                context.tracks.Remove(track);
                context.SaveChanges();
            }
        }

        public List<Track> GetAll()
        {
            return context.tracks.ToList();
        }

        public Track GetById(int id)
        {
            var track = context.tracks.FirstOrDefault(x => x.Id == id);
            if (track != null) {
                return (track);
            }
            else
            {
                throw new Exception("Not Found");
            }
        }

        public void Update(int id,Track track)
        {
            var currTrack =context.tracks.FirstOrDefault(i=>i.Id==id);

            if (currTrack != null)
            {
                currTrack.Name= track.Name;
                currTrack.Description= track.Description;
                context.SaveChanges();
            }
        }
    }
}
