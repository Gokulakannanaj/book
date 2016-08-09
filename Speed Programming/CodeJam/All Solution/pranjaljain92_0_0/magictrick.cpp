#include<iostream>
#include<cstdio>
#include<vector>

using namespace std;

int main()
{
    FILE *fin,*fout;
    fin=fopen("A-small-attempt0.in","r");
    fout=fopen("output.txt","w");

    int i,t,x,row,j,count,ans;
    int arr[5][5];
    fscanf(fin,"%d",&t);
    for(x=1;x<=t;x++)
    {
        vector<int> hash(17,0);
        fscanf(fin,"%d",&row);
        for(i=1;i<=4;i++)
        for(j=1;j<=4;j++)
        fscanf(fin,"%d",&arr[i][j]);

        for(j=1;j<=4;j++)
        hash[arr[row][j]]=1;

        count=0;
        fscanf(fin,"%d",&row);
        for(i=1;i<=4;i++)
        for(j=1;j<=4;j++)
        fscanf(fin,"%d",&arr[i][j]);

        for(j=1;j<=4;j++)
        {
            if(hash[arr[row][j]])
            {
                count++;
                ans=arr[row][j];
            }
        }
        fprintf(fout,"Case #%d: ",x);
        if(count==0)
        fprintf(fout,"Volunteer cheated!\n");
        else if(count==1)
        fprintf(fout,"%d\n",ans);
        else
        fprintf(fout,"Bad magician!\n");
    }
    return(0);
}
