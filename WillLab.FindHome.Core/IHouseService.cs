using System.Threading.Tasks;
using WillLab.FindHome.Model;

namespace WillLab.FindHome.Core
{
    public interface IHouseService
    {
        Task<FindHouseResultModel> FindHouseAsync(string address, string city, string state, string zipcode);
    }
}
