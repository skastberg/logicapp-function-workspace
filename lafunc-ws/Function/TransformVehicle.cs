//------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
//------------------------------------------------------------

namespace contoso.functions
{
    using System;
    using System.Collections.Generic;
    using System.Text.Json;

    using System.Text.Json.Serialization;

    using System.Threading.Tasks;
    using Microsoft.Azure.Functions.Extensions.Workflows;
    using Microsoft.Azure.Functions.Worker;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// Represents the TransformVehicle flow invoked function.
    /// </summary>
    public class TransformVehicle
    {
        private readonly ILogger<TransformVehicle> logger;

        public TransformVehicle(ILoggerFactory loggerFactory)
        {
            logger = loggerFactory.CreateLogger<TransformVehicle>();
        }

        /// <summary>
        /// Transforms a vehicle and sometimes cheats with the year.
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        [Function("TransformVehicle")]
        public Task<Vehicle> Run([WorkflowActionTrigger] Vehicle vehicle)
        {
            this.logger.LogInformation("Accepted {body}", JsonSerializer.Serialize(vehicle));

            // Generate random temperature within a range based on the temperature scale
            Random rnd = new Random();
            var cheatWithYears = rnd.Next(0, 2);

            var transformedVehicle = new Vehicle()
            {
                Brand = vehicle.Brand.ToUpper(),
                Model = vehicle.Model.ToUpper(),
                Year = vehicle.Year + cheatWithYears,
                Type = vehicle.Type
            };

            this.logger.LogInformation("Returning {body}", JsonSerializer.Serialize(transformedVehicle));

            return Task.FromResult(transformedVehicle);
        }
    }
}
