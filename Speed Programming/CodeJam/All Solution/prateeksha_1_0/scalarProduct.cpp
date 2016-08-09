#include<iostream>
#include<vector>
#include<algorithm>
using namespace std;

int main()
{
	freopen("A-large-practice.in","r",stdin);
	freopen("out.txt","w",stdout);
	int t;
	cin>>t;
	for(int i=1;i<=t;++i)
	{
		int n;
		cin>>n;
		vector<int> a(n),b(n);
		for(int j=0;j<n;++j)
			cin>>a[j];
		for(int j=0;j<n;++j)
			cin>>b[j];
		
		long long ans=0;
		sort(b.begin(),b.end());
		sort(a.begin(),a.end());
		for(int j=0;j<n;++j)
			ans+=(a[j]*b[n-j-1]);
		cout<<"Case #"<<i<<": "<<ans<<endl;
	}
	return 0;
}
