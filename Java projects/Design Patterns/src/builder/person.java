package builder;

public class person {

    private String name;
    private String surname;
    private int age;

    // Constructor that accepts a Builder object
    public person(Builder builder) {
        this.name = builder.name;
        this.surname = builder.surname;
        this.age = builder.age;
    }

    // Optionally, override the toString() method
    @Override
    public String toString() {
        return "person{name='" + name + "', surname='" + surname + "', age=" + age + "}";
    }



    public static class Builder {
        private String name;
        private String surname;
        private int age;

        public Builder name(String name){
            this.name = name;
            return this;
        }

        public Builder surname(String surname){
            this.surname = surname;
            return this;
        }

        public Builder age(int age){
            this.age = age;
            return this;
        }

        public person build(){
            return new person(this); // Now this constructor exists
        }
    }
}