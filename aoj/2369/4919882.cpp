// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2369/judge/4919882/C++14
#include<bits/stdc++.h>

using ll = long long;
#define var auto

using namespace std;

template<typename T1,typename T2> inline void chmin(T1 &a,T2 b){if(a>b) a=b;}
template<typename T1,typename T2> inline void chmax(T1 &a,T2 b){if(a<b) a=b;}

string s;

void judge(int& i){
    if (s[i] != 'm') return;
    i++;
    judge(i);
    if (s[i] != 'e') return;
    i++;
    judge(i);
    if (s[i] != 'w') return;
    i++;
}

int main(){
    cin >> s;
    int i = 0;
    judge(i);
    cout << (i == s.size() ? "Cat" : "Rabbit") << endl;
}

