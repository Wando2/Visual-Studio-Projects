package builder;

public class teste {

    public static void main(String[] args) {
        person p = new person.Builder()
                .name("John")
                .surname("Doe")
                .age(30)
                .build();
                
        System.out.println(p);
    }
}