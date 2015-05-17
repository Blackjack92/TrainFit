using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace TrainFit.Services
{
    public class GPSService : BindableBase
    {
        #region fields
        private Geolocator geolocator;
        #endregion

        #region properties
        #endregion

        #region ctor
        public GPSService()
        {
            geolocator = new Geolocator();
            geolocator.DesiredAccuracyInMeters = 5;
        }
        #endregion

        #region methods
        // TODO: Remove this method if not needed
        //public async Geoposition GetPosition()
        //{
        //    var cancellationTokenSource = new CancellationTokenSource();
        //    var token = cancellationTokenSource.Token;

        //    // Carry out the operation 
        //    return await geolocator.GetGeopositionAsync().AsTask(token); 
        //}
        #endregion
    }
}
