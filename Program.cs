using Microsoft.AspNetCore.OData;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using OdataText;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers().AddOData(opt => opt.Count().Filter().Expand().Select().OrderBy().SetMaxTop(1000).AddRouteComponents("odata", GetEdmModel2()));
var app = builder.Build();
app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();

static IEdmModel GetEdmModel1()
{
    var builder = new ODataConventionModelBuilder();
    builder.EntitySet<Main>(nameof(Main));
    builder.ComplexType<Properties>().Property(e => e.Property1).Name = "Ware";
    var model = builder.GetEdmModel();
    return model;
}

static IEdmModel GetEdmModel2()
{
    var builder = new ODataConventionModelBuilder();
    builder.EntitySet<Main>(nameof(Main));
    
    builder.EntityType<Main>().Ignore(e => e.Properties);
    var model = builder.GetEdmModel();
    var mainType = model.SchemaElements.OfType<EdmEntityType>().First(c => c.Name == "Main") as EdmEntityType;
    var wareProperty = mainType.AddStructuralProperty("Ware", EdmCoreModel.Instance.GetString(false));
    var property1Info = typeof(Properties).GetProperty("Property1");
    model.SetAnnotationValue(wareProperty, new ClrPropertyInfoAnnotation(property1Info));

    return model;
}
