using SerComm.eProcurementV2.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace SerComm.eProcurementV2.Permissions
{
    public class eProcurementV2PermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(eProcurementV2Permissions.GroupName);
            //Define your own permissions here. Example:
            //myGroup.AddPermission(eProcurementV2Permissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<eProcurementV2Resource>(name);
        }
    }
}
