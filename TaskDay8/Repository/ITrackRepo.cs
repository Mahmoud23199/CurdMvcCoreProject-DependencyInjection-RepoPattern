using TaskDay8.Models;

namespace TaskDay8.Repository
{
    public interface ITrackRepo
    {
        public List<Track> GetAll();
        public Track GetById(int id);

        public void Create(Track track);
        public void Update(int id,Track track);

        public void DeleteById(int id);
    }
}
