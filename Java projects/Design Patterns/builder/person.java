
public class person{

    private String name;
    private String surname;
    private int age;

    @Override
    public String toString() {
        return "Builder{" +
                "name='" + name + '\'' +
                ", surname='" + surname + '\'' +
                ", age=" + age +
                '}';
    }

    static class Builder{
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
            person p = new person();
            p.name = this.name;
            p.surname = this.surname;
            p.age = this.age;
            return p;
        }

       
    }
}