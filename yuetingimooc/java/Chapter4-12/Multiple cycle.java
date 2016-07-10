
public class Multiple cycle {
    public static void main(String[] args) {
        
		System.out.println("打印直角三角形");
		for (int i = 1;i<=3;i++) {
                for (int j = 1; j<=i;j++) {
                
		System.out.print("*");
			}
		System.out.println();
		}
                System.out.println("打印正方形");
                for (int i = 1; i<=3;i++) {
                for (int j = 1; j<=5;j++) {
                
    		System.out.print("*");
			}
     
		System.out.println();
		}
	}
}