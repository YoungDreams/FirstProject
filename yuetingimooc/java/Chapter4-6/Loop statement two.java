public class Loop statement two{
    public static void main(String[] args) {
        
		int sum = 0; // ���� 1-50 ֮��ż���ĺ�
        
		int num = 2; // ���� 1-50 ֮���ż��
        
		do {
			//ʵ���ۼ����
            sum+=num;//����sum=sum+num
            
			num = num + 2; // ÿִ��һ�ν���ֵ��2���Խ����´�ѭ�������ж�
            
		} while (num<=50&&num%2==0); // ������ֵ�� 1-50 ֮��ʱ�ظ�ִ��ѭ��
        
		System.out.println(" 50���ڵ�ż��֮��Ϊ��" + sum );
	}
}