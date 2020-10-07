// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/1628/judge/4896359/C++14
#include<bits/stdc++.h>

using namespace std;

#define var auto
#define ll long long


signed main(){
  while (true){
    ll n;
    cin >> n;
    if (n == 0) break;
    ll a = 1;
    string bs;
    cin >> bs;
    for (int i = 0; i < 52; i++){
      a <<= 1;
      a += (bs[i] - '0');
    }
    //cout << "a" << endl;
    const ll MAX = 1L << 53;
    //cout << a << endl;
    //cout << MAX << endl;
    int se = 0;
    ll sm = a;
    while (0 < n && a != 0){
      ll gap = MAX - sm;
      ll next = (gap + a - 1)/ a;
      ll step = min(next, n);
      n -= step;
      sm += a * step;
      //cout << gap << " " << step << " " << n << endl;
      if (sm >= MAX){
        se++;
        sm >>= 1;
        a >>= 1;
      }
    }

    string ses = "";
    string sms = "";
    for (int i = 11; i >= 0; i--){
      ses += '0' + ((se >> i) & 1);
    }
    for (int i = 51; i >= 0; i--){
      sms += '0' + ((sm >> i) & 1);
    }

    cout << ses + sms << endl;
  }
  return 0;
}


