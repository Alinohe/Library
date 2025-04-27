using Library.Data;
using Microsoft.Extensions.DependencyInjection;
using Library;
using Library.UserComminucation;
using Library.Data.Entities;
using Library.Data.Repositories;

var services = new ServiceCollection();
services.AddSingleton<IApp, App>();
services.AddSingleton<IUserCommunication, UserCommunication>();
services.AddSingleton<Book>();
services.AddSingleton<IRepository<Book>, WriteInFileRepository<Book>>();
services.AddSingleton<IRepository<Book>, SqlRepository<Book>>();
services.AddSingleton<IRepository<Book>, ListRepository<Book>>();
services.AddSingleton<IRepository<Client>, WriteInFileRepository<Client>>();
services.AddSingleton<IRepository<Client>, SqlRepository<Client>>();
services.AddSingleton<IRepository<Client>, ListRepository<Client>>();
services.AddSingleton<IRepository<Employee>, WriteInFileRepository<Employee>>();
services.AddSingleton<IRepository<Employee>, SqlRepository<Employee>>();
services.AddSingleton<IRepository<Employee>, ListRepository<Employee>>();
services.AddSingleton<IRepository<Librarian>, WriteInFileRepository<Librarian>>();
services.AddSingleton<IRepository<Librarian>, SqlRepository<Librarian>>();
services.AddSingleton<IRepository<Librarian>, ListRepository<Librarian>>();

services.AddSingleton<IBooksData, BooksData>();

var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetService<IApp>();
var userCommunication = serviceProvider.GetService<IUserCommunication>();
app.Run();

//userCommunication.MainMenu();

