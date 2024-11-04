package factory;

public class productFactory {
    public static product getInstance(productType type){
        if(type.equals(productType.PHYSICAL)){
             product product = new physicalProduct();
             product.setHasPhysicalDimensions(true);
            return product;}
        else if(type.equals(productType.DIGITAL)){
            product product = new digitalProduct();
            product.setHasPhysicalDimensions(false);
            return product;
        }
        else{
            return null;
        }
    }
}
