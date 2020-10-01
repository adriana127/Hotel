using Hotel.View_Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Model.Entity.Actions
{
    public class RoomActions
    {
        public RoomActions() { }
        public room GetRoomById(int id)
        {
            HotelEntities context = new HotelEntities();

            room aux = new room();
            foreach (var room in context.rooms.ToList())
            {
                if (room.id == id)
                {
                    aux = room;break;
                }
            }
            return aux;
        }
        public ObservableCollection<RoomDisplay> GetRooms()
        {
            HotelEntities context = new HotelEntities();
            ObservableCollection<RoomDisplay> auxList = new ObservableCollection<RoomDisplay>();
            foreach (var room in context.rooms.ToList())
            {
                if (room.recordStatus == "Active")
                {

                    var poze = context.roomPhotoes.ToList();
                    roomPhoto roomPhoto = new roomPhoto();
                    foreach (var poza in poze)
                    {
                        if (poza.idRoom == room.id)
                        {
                            roomPhoto = poza;
                            break;
                        }
                    }
                    auxList.Add(new RoomDisplay( room.price.ToString(), room.capacity.ToString(), roomPhoto.photoPath,room.id));

                }
            }
            return auxList;

        }
        public void AddPhoto(int id)
        {
            HotelEntities context = new HotelEntities();

            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.ShowDialog();
            FileStream fs = new FileStream(dlg.FileName, FileMode.Open, FileAccess.Read);
            byte[] data = new byte[fs.Length];
            fs.Read(data, 0, System.Convert.ToInt32(fs.Length));
            fs.Close();


            string iName = dlg.FileName;
            string folder = @"\Image\";
            var path = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.FullName, Path.GetFileName(iName));
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            context.AddPhoto( id, path);

            string currentFolder = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.FullName;
            File.Copy(iName, path);
        }

        public ObservableCollection<feature> GetFeatures()
        {
            HotelEntities context = new HotelEntities();
            ObservableCollection<feature> auxList = new ObservableCollection<feature>();
            foreach (var feature in context.features.ToList())
            {
                auxList.Add(feature);
            }
            return auxList;
        }

        public ObservableCollection<roomPhoto> GetPhotos(int idRoom)
        {
            HotelEntities context = new HotelEntities();

            var poze = context.roomPhotoes.ToList();
            ObservableCollection<roomPhoto> pozePreparat = new ObservableCollection<roomPhoto>();

            foreach (var photo in poze)
            {
                if (photo.idRoom == idRoom)
                    pozePreparat.Add(photo);
            }

            return pozePreparat;
        }

        internal void DeletePhoto(int idPoza)
        {
            HotelEntities context = new HotelEntities();
            context.DeletePhoto(idPoza);
            context.SaveChanges();
        }


        public void Save(int id, string price, string capacity, string numberOfRooms, feature selectedFeature,account cont)
        {
            HotelEntities context = new HotelEntities();
            if (id == -1)
            {
                context.AddRoom(int.Parse(capacity), int.Parse(numberOfRooms), int.Parse(price), selectedFeature.id);
                context.SaveChanges();
            }
            else
            {
                context.ModifyRoom(id, int.Parse(numberOfRooms), int.Parse(price), selectedFeature.id, int.Parse(capacity));
                context.SaveChanges();

            }
            MainViewModel.Instance.ActiveScreen = new RoomsViewModel(cont);
        }

        public void Delete(int id,account cont)
        {
            HotelEntities context = new HotelEntities();
            context.RemoveRooms(id);
            MainViewModel.Instance.ActiveScreen = new RoomsViewModel(cont);

        }
    }
}
