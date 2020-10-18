// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2182/judge/4922554/C++14
#include<bits/stdc++.h>

using ll = long long;
#define var auto

using namespace std;

template<typename T1,typename T2> inline void chmin(T1 &a,T2 b){ if(a > b) a = b; }
template<typename T1,typename T2> inline void chmax(T1 &a,T2 b){ if(a < b) a = b; }

int main(){
  //入力読む
  string s;
  cin >> s;
  if (s == "0") return 0;
  //反転?
  reverse(s.begin(), s.end());
  //最初からの累積での11で割った余り + zero-sum ranges 
  vector<int> kinds(11);
  int cur = 0;
  int dig = 1;
  kinds[cur]++;
  ll res = 0;
  for (var&& c : s){
    var a = c - '0';
    cur = (cur + a * dig) % 11;
    dig = (dig * 10) % 11;
    if (a != 0) res += kinds[cur];
    kinds[cur]++;
  }
  cout << res << endl;

  main();
}

