// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2155/judge/4927638/C++17
#include<bits/stdc++.h>

using ll = long long;
#define var auto

using namespace std;

template<typename T1,typename T2> inline void chmin(T1 &a,T2 b){ if (a > b) a = b; }
template<typename T1,typename T2> inline void chmax(T1 &a,T2 b){ if (a < b) a = b; }

int main(){
  int n, m;
  cin >> n >> m;
  if (n == 0) return 0;
  using P = pair<int, int>;
  using PP = pair<int, P>;
  vector<PP> v{};
  for (int i = 0; i < m; i++){
    int t, s, d;
    cin >> t >> s >> d;
    v.emplace_back(t, P(s - 1, d - 1));
  }
  sort(v.begin(), v.end());
  vector<bool> infected(n);
  infected[0] = 1;
  for (var&& item : v){
    var [s, d] = item.second;
    infected[d] = infected[d] | infected[s];
  }
  int res = 0;
  for (int i = 0; i < n; i++){
    if (infected[i]) res++;
  }
  cout << res << endl;
  main();
}

