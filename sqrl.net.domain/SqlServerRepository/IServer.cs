using Microsoft.SqlServer.Management.Smo;

namespace sqrl.net.domain.db_interface
{
    public interface IServer
    {
        DatabaseCollection Databases { get; }
    }
}