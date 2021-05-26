using OMS.Core.Interface.Entity;
using System;

namespace OMS.Core.Common
{
    public static class EntityExtension
    {
        public static void SetCreatedAudit(this IAudit audit, string username)
        {
            audit.CreatedBy = username;
            audit.UpdatedBy = username;
            audit.CreatedDate = DateTime.UtcNow;
            audit.UpdatedDate = DateTime.UtcNow;
        }

        public static void SetUpdatedAudit(this IAudit audit, string username)
        {
            audit.UpdatedBy = username;
            audit.UpdatedDate = DateTime.UtcNow;
        }
    }
}
