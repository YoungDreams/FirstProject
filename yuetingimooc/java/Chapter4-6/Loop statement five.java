public class Loop statement five{
    public static void main(String[] args) {
		int sum = 0;
		for (int i = 1; i <= 10; i++) {
		sum = sum + i;
        if (sum>20) {
		System.out.println("��ǰ���ۼ�ֵΪ:" + sum);
		      break;
			}
		}
        int num =0;
        for (int i = 1; i <= 10; i++) {
		num = num + i;
		if ((num=num+i)>20) {	
		System.out.println("��ǰ���ۼ�ֵΪ:" +num);
		      break; 
		 }
	}
}
}
          //��ע��Ϊʲô������������ͬ��