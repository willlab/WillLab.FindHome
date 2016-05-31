using System;
using System.Threading.Tasks;
using WillLab.FindHome.Core;
using WillLab.FindHome.Zillow;
using WillLab.FindHome.Model;

namespace WillLab.FindHome.Service
{
    public class HouseService : IHouseService, IDisposable
    {
        /// <summary>
        /// Find house by address
        /// </summary>
        /// <param name="address">street</param>
        /// <param name="city">city</param>
        /// <param name="state">state</param>
        /// <param name="zip">zip</param>
        /// <returns>house info result</returns>
        public async Task<FindHouseResultModel> FindHouseAsync(string address, string city, string state, string zip)
        {
            IHouseProvider provider = new ZillowHouseProvider();
            return await provider.FindHouseAsync(address, city, state, zip);
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~HouseService() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
