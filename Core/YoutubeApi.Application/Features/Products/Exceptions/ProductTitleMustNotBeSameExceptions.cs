namespace YoutubeApi.Application.Features.Products.Exceptions;

public class ProductTitleMustNotBeSameExceptions : Exception
{
    public ProductTitleMustNotBeSameExceptions() : base("Ürün başlığı zaten var!!"){}
}