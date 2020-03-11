using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using TodoApp.DAL;
using TodoApp.DAL.Models;
using TodoApp.Infra.Interfaces;

namespace TodoApp.Tests.Core
{
    public class UnitOfWorkTests
    {
        private IUnitOfWork _unitOfWork;
        private ApplicationContext _context;
        
        [SetUp]
        public void Setup()
        {
            _context = new ApplicationContext(new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase("tests")
                .Options);
            var factoryMock = new Mock<IRepositoryFactory>();
            factoryMock
                .Setup(x => x.Create<TaskModel>())
                .Returns(new Repository<TaskModel>(_context.Tasks));
            _unitOfWork = new UnitOfWork(_context, factoryMock.Object);    
        }

        [Test]
        [Order(0)]
        public void ShouldNotAddEntityToDb()
        {
            var insertedCount = 5;
            var beforeLength = _context.Tasks.Count();
            Enumerable.Range(0, insertedCount).ToList().ForEach(x => _context.Tasks.Add(new TaskModel() { }));
            var afterLength = _context.Tasks.Count();
            Assert.AreNotEqual(beforeLength + insertedCount, afterLength);
        }
        
        [Test]
        [Order(1)]
        public async Task ShouldAddEntityToDb()
        {
            var insertedCount = 5;
            var beforeLength = _context.Tasks.Count();
            Enumerable.Range(0, insertedCount).ToList().ForEach(x => _context.Tasks.Add(new TaskModel() { }));
            await _unitOfWork.CommitAsync();
            var afterLength = _context.Tasks.Count();
            Assert.AreEqual(beforeLength + insertedCount, afterLength);
        }
    }
}