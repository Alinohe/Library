
namespace Library.Repositories;
using Library.Repositories;
using Library.Repositories.Repositories;
using Library.Entities;
using System.Text.Json;

public class WriteInFileRepository<T> : IRepository<T> where T : class, IEntity, new()
{
    public string LFile;
    public Action<Books> bookAdded;
    public WriteInFileRepository(string file, Action<Books> bookAdded)
    {
        LFile = file;
        this.bookAdded = bookAdded;
    }

    private const string fileName = "Library.json";
    private readonly Action<T>? _itemAddedCallback;
    private readonly Action<T>? _itemRemovedCallback;
    private static int lastId = 0;
    protected List<T> items = new();

    public WriteInFileRepository(Action<T>? itemAddedCallback = null, Action<T>? itemRemovedCallback = null)
    {
        _itemAddedCallback = itemAddedCallback;
        _itemRemovedCallback = itemRemovedCallback;
    }

    public event EventHandler<T> ItemAdded;
    public event EventHandler<T> ItemRemoved;


    //sprawdzic czy nie throw new Exception
    public T? GetById(int id)
    {
        throw new NotImplementedException();
        //if (File.Exists(fileName))
        //{
        //    using (var streamReader = new StreamReader(fileName))
        //    {
        //        var json = streamReader.ReadToEnd();
        //        items = string.IsNullOrWhiteSpace(json)
        //            ? new List<T>()
        //            : JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
        //    }
        //}
        //else
        //{
        //    throw new Exception("File doesn't exist");
        //}
        //return items.FirstOrDefault(x => x.Id == id);
    }



    public IEnumerable<T> GetAll()
    {
        if (File.Exists(fileName))
        {
            using (var streamReader = new StreamReader(fileName))
            {
                var json = streamReader.ReadToEnd();
                if (string.IsNullOrWhiteSpace(json))
                {
                    throw new Exception("Nie Ma Zadnych ksiazek w bibliotece");
                }
                else
                {
                    return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
                }
            }
        }
        else
        {
            throw new Exception("Nie mozna znalezc pliku");
        }
    }

    public void Add(T item)
    {
        if (File.Exists(fileName))
        {
            using (var reader = new StreamReader(fileName))
            {
                var json = reader.ReadToEnd();
                items = string.IsNullOrWhiteSpace(json)
                    ? new List<T>()
                    : JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
            }
        }
        else
        {
            items = new List<T>();
        }

        lastId = items.Count > 0
            ? items.Max(x => x.Id)
            : 0;

        item.Id = ++lastId;

        items.Add(item);

        using (var writer = new StreamWriter(fileName))
        {
            var newJson = JsonSerializer.Serialize(items);
            writer.Write(newJson);
        }
        _itemAddedCallback?.Invoke(item);
        ItemAdded?.Invoke(this, item);
    }

    public void Remove(T item)
    {
        if (File.Exists(fileName))
        {
            using (var streamReader = new StreamReader(fileName))
            {
                var json = streamReader.ReadToEnd();
                items = string.IsNullOrWhiteSpace(json) ? new List<T>()
                    : JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();

            }
        }
        else
        {
            throw new Exception("Lista Ksiazek nie istnieje");
        }

        var _itemToRemove = items.FirstOrDefault(x => x.Id == item.Id);
        items.Remove(_itemToRemove);
        _itemRemovedCallback?.Invoke(item);
        ItemRemoved?.Invoke(this, item);

        using (var streamWriter = new StreamWriter(fileName))
        {
            var newJson = JsonSerializer.Serialize(items);
            streamWriter.Write(newJson);
        }
    }

    public void Save()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Ksiazka zostala zapisna w pliku 'library.json'" + Environment.NewLine);
        Console.ResetColor();
    }


    private string _fileName;
    private List<IEntity> _items;
    public WriteInFileRepository(string fileName)
    {
        _fileName = fileName;
        _items = new List<IEntity>();
        Load();
    }
    //public void Add(IEntity item)
    //{
    //    if (item.Id == 0)
    //    {
    //        item.Id = _items.Count == 0 ? 1 : _items.Max(x => x.Id) + 1;
    //    }
    //    _items.Add(item);
    //}
    public void Update(IEntity item)
    {
        var existingItem = _items.FirstOrDefault(x => x.Id == item.Id);
        if (existingItem != null)
        {
            _items.Remove(existingItem);
            _items.Add(item);
        }
    }
    public void Delete(int id)
    {
        var existingItem = _items.FirstOrDefault(x => x.Id == id);
        if (existingItem != null)
        {
            _items.Remove(existingItem);
        }
    }
    private void Load()
    {
        if (File.Exists(_fileName))
        {
            var json = File.ReadAllText(_fileName);
            _items = JsonSerializer.Deserialize<List<IEntity>>(json);
        }
    }

}
