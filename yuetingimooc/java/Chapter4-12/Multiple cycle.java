
public class Multiple cycle {
    public static void main(String[] args) {
        
		System.out.println("��ӡֱ��������");
		for (int i = 1;i<=3;i++) {
                for (int j = 1; j<=i;j++) {
                
		System.out.print("*");
			}
		System.out.println();
		}
                System.out.println("��ӡ������");
                for (int i = 1; i<=3;i++) {
                for (int j = 1; j<=5;j++) {
                
    		System.out.print("*");
			}
     
		System.out.println();
		}
	}
}