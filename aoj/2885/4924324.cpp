// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/2885/judge/4924324/C++14
#include<bits/stdc++.h>

using ll = long long;
#define var auto

using namespace std;

template<typename T1,typename T2> inline void chmin(T1 &a,T2 b){ if(a > b) a = b; }
template<typename T1,typename T2> inline void chmax(T1 &a,T2 b){ if(a < b) a = b; }

int main(){
  //入力
  int n, m;
  cin >> n >> m;
  if (n == 0) return 0;
  vector<pair<int, int>> v;
  vector<vector<int>> g(n);
  for (int i = 0; i < m; i++){
    int s, t;
    cin >> s >> t;
    s--; t--;
    g[s].push_back(t);
    g[t].push_back(s);
    v.emplace_back(s, t);
  }
  //DFSします
  vector<int> d(n);
  stack<int> st{};
  st.push(0);
  d[0] = 1;
  while (!st.empty()){
    var elem = st.top(); st.pop();
    for (var&& adj : g[elem]){
      if (d[adj] != 0) continue;
      d[adj] = -d[elem];
      st.push(adj);
    }
  }
  //辺舐めてvalidness
  bool valid = true;
  for (var&& edge : v){
    valid &= d[edge.first] != d[edge.second];
  }
  //グループの数数えてvectorに入れてえい
  int cnt1 = 0;
  for (int i = 0; i < n; i++) if (d[i] == 1) cnt1++;
  vector<int> res{};
  if (valid && cnt1 % 2 == 0) res.push_back(cnt1 / 2);
  var cnt2 = n - cnt1;
  if (valid && cnt1 != cnt2 && cnt2 % 2 == 0){ 
    res.push_back(cnt2 / 2);
  }
  sort(res.begin(), res.end());
  cout << res.size() << endl;
  for (var&& c : res){
    cout << c << endl;
  }
  main();
}

