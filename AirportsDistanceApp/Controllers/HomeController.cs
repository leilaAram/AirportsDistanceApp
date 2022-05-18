using Core.IOModels;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirportsDistanceApp.Controllers
{
    public class HomeController : BaseWebController
    {
        private ICalculatingDistanceService _calculatingDistanceService;

        public HomeController( ICalculatingDistanceService calculatingDistanceService )
        {
            _calculatingDistanceService = calculatingDistanceService;
        }


        /// <summary>
        /// Calculating distance of two airports
        /// <param name="source">source</param>
        /// <param name="destination">destination</param>
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Indicates that distance is calculated.</response>
        [HttpGet( "from/{source}/to/{destination}" )]
        public async Task<IActionResult> GetDistance( [FromRoute] string source, [FromRoute] string destination )
        {
            if( string.IsNullOrEmpty( source ) || string.IsNullOrEmpty( destination ) )
            {
                return BadRequest( new JsonResponse { IsSuccess = false, ErrorCode = Core.Enums.ErrorCodes.Source_Destication_Is_Required } );
            }
            var result = await _calculatingDistanceService.CalculateAirportsDistanceAsync( source, destination );

            return Ok( result );
        }

    }
}
