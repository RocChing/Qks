using System;
using System.Collections.Generic;
using System.Text;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Qks.GraphQL.Abstractions
{
    public class QksGraphQLAbstractionModule : AbpModule
    {
        public override void Initialize()
        {
            var thisAssembly = typeof(QksGraphQLAbstractionModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);
        }
    }
}
