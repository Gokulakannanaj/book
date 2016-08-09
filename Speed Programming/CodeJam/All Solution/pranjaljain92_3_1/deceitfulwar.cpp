#include<iostream>
#include<cstdio>
#include<algorithm>

using namespace std;

int main()
{
    FILE *fin,*fout;
    fin=fopen("D-large.in","r");
    fout=fopen("output.txt","w");
    int i,n,t,points1,points2,j,x,a,b;
    double arr[1009],brr[1009];
    fscanf(fin,"%d",&t);
    for(x=1;x<=t;x++)
    {
        fscanf(fin,"%d",&n);
        for(i=0;i<n;i++)
        fscanf(fin,"%lf",&arr[i]);
        for(i=0;i<n;i++)
        fscanf(fin,"%lf",&brr[i]);

        sort(arr,arr+n);
        sort(brr,brr+n);

        points1=0;points2=0;
        for(i=0,j=0;i<n && j<n;)
        {
            if(arr[i]<brr[j])
            {
                i++;j++;
            }
            else
            j++;
        }
        points1=n-i;

        i=0;j=n-1;a=0;b=n-1;
        while( i<=j && a<=b)
        {
            if(arr[i]<brr[a])
            {
                i++;b--;
            }
            else
            {
                i++;a++;points2++;
            }
        }

        fprintf(fout,"Case #%d: %d %d\n",x,points2,points1);
    }
    return(0);
}
