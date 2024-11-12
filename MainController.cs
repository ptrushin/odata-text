using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace OdataText;

public class MainController : ODataController
{
    [HttpGet]
    [EnableQuery]
    public ActionResult<IQueryable<Main>> Get(ODataQueryOptions<Main> queryOptions)
    {
        return Ok(new List<Main> {
            new Main { Properties = new Properties { Property1 = "Ware1" } },
            new Main { Properties = new Properties { Property1 = "Ware2" } },
        }.AsQueryable());
    }
}