package factory;

public class testeFactory {
    public static void main(String[] args) {
        product product = productFactory.getInstance(productType.PHYSICAL);
        System.out.println(product.getHasPhysicalDimensions());
        product product2 = productFactory.getInstance(productType.DIGITAL);
        System.out.println(product2.getHasPhysicalDimensions());
    }
}