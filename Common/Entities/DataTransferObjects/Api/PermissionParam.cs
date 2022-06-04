using Common.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Common.Entities.DataTransferObjects.Api
{
    public class PermissionParam
    {
        public List<LocationInfo> LocationsPermission { get; set; } = null;
        public List<string> ConstructionIds { get; set; } = null;
        public List<UserPermission> UserPermissions { get; set; } = null;
        public string CustomerId { get; set; } = null;
        public OptionalParam<PageParametersDto> Paging { get; set; } = null;
        public CancellationToken CancellationToken { get; set; } = default;
        public string UserName { get; set; } = null;
        public List<string> Roles { get; set; } = null;
    }
}
