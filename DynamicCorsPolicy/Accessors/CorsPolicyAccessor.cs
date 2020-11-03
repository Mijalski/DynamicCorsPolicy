﻿using System;
using DynamicCorsPolicy.Enums;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.Options;

namespace DynamicCorsPolicy.Accessors
{
    internal class CorsPolicyAccessor : ICorsPolicyAccessor
    {
        private readonly CorsOptions _options;

        public CorsPolicyAccessor(IOptions<CorsOptions> options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            _options = options.Value;
        }

        public CorsPolicy GetPolicy()
        {
            return _options.GetPolicy(CorsPoliciesEnums.DynamicCorsPolicyName);
        }

        public CorsPolicy GetPolicy(string name)
        {
            return _options.GetPolicy(name);
        }
    }
}