using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using TodoApp.Core;
using TodoApp.DAL;
using TodoApp.DAL.Models;
using TodoApp.Infra.Dto;
using TodoApp.Infra.Interfaces;

namespace TodoApp.Tests.Core
{
    public class TasksServiceTests
    {
        private ITasksService _tasksService;
        
        [SetUp]
        public void Setup()
        {
            var dbContext = new ApplicationContext(new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase("tests")
                .Options);
            var mapper = new Mapper(new MapperConfiguration(cfg => {
                cfg.AddMaps(AppDomain.CurrentDomain.GetAssemblies());
            }));
            var taskRepositoryMock = new Mock<IRepository<TaskModel>>();
            taskRepositoryMock
                .Setup(x => x.GetByIdAsync(It.IsAny<int>()))
                .Returns<int>(id => Task.FromResult(dbContext.Tasks.Find(id)));
            taskRepositoryMock
                .Setup(x => x.CreateAsync(It.IsAny<TaskModel>()))
                .Returns<TaskModel>(task => Task.FromResult(dbContext.Tasks.Add(task)));
            var repositoryFactoryMock = new Mock<IRepositoryFactory>();
            repositoryFactoryMock
                .Setup(x => x.Create<TaskModel>())
                .Returns(taskRepositoryMock.Object);  
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock
                .Setup(x => x.GetRepository<TaskModel>())
                .Returns(repositoryFactoryMock.Object.Create<TaskModel>());
            unitOfWorkMock
                .Setup(x => x.CommitAsync())
                .Returns(Task.FromResult(dbContext.SaveChanges()));
            _tasksService = new TasksService(unitOfWorkMock.Object, mapper);
        }

        [Test]
        [Order(0)]
        public async Task ShouldCreateTask()
        {
            var expectedId = (await _tasksService.Get()).Count() + 1;
            var task = await _tasksService.CreateTask(new TaskDto());
            Assert.AreEqual(expectedId, task.Id);
        }
        
        [Test]
        [Order(1)]
        public async Task ShouldReturnTask()
        {
            var createdTask = await _tasksService.CreateTask(new TaskDto());
            var task = await _tasksService.GetById(createdTask.Id);
            Assert.AreEqual(task.Id, createdTask.Id);
        }
    }
}