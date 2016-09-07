using ServiceStation.DataAccessLayer.Context;
using ServiceStation.DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.DataAccessLayer.UnitOfWork
{
    class UnitOfWork : IDisposable
    {
        private DataBaseContext _db;
        private bool _disposed = false;
        private ClientRepository _clientRepository;
        private AutoRepository _autoRepository;
        private OrderRepository _orderRepository;

        public ClientRepository Clients
        {
            get
            {
                if(_clientRepository == null)
                {
                    _clientRepository = new ClientRepository(_db);
                }
                return _clientRepository;
            }
        }
        public AutoRepository Cars
        {
            get
            {
                if (_autoRepository == null)
                {
                    _autoRepository = new AutoRepository(_db);
                }
                return _autoRepository;
            }
        }
        public OrderRepository Orders
        {
            get
            {
                if (_orderRepository == null)
                {
                    _orderRepository = new OrderRepository(_db);
                }
                return _orderRepository;
            }
        }
        public UnitOfWork()
        {
            _db = new DataBaseContext();
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
                this._disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
