public class Loop statement six {
    public static void main(String[] args) {

	    int sum = 0; // �����ۼ�ֵ
	    for (int i = 1; i <= 10; i++) {
	    if (i%2 ==0) {
            sum=sum+i;
			}  
            continue;
              }
	    System.out.print("1��10֮�������ż���ĺ�Ϊ��" + sum);
        
            int number= 0 ;
            for(int i=1;i<=15;i++){
            if(i%3 !=0){
            number=number+i;
        }
            continue;
    }
	    System.out.print("1��10֮������������ĺ�Ϊ��" + number);

	}
}
             //��ע��continue��break���ֵ��÷�һ��������ʲô�ط���