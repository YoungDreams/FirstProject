public class  Operation parity{
      public static void main(String[] args) {
            int one = 20 ;
        if(one%2==0){
            System.out.println("one是偶数");
	    }
            else{
            System.out.println("one是奇数");}
    
           int two=35;
           int three=one+two;
           if (three%3==0){
           System.out.println("three是偶数");
}
           else{
           System.out.println("three是奇数");
           int four=one+two+three;
           if (four%5==0){
           System.out.println("four是偶数");
}
           else{
           System.out.println("four是奇数");
           
    }
 
  }
	}
}