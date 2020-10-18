// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/1196/judge/4922427/C++14
#include<bits/stdc++.h>

using ll = long long;
#define var auto

using namespace std;

template<typename T1,typename T2> inline void chmin(T1 &a,T2 b){ if(a > b) a = b; }
template<typename T1,typename T2> inline void chmax(T1 &a,T2 b){ if(a < b) a = b; }

int main(){
  //入力読む
  int n;
  cin >> n;
  if (n == 0) return 0;
  vector<int> p(n);
  for (int i = 1; i < n; i++){
    cin >> p[i];
    p[i]--;
  }
  int edgesum = 0;
  vector<int> d(n);
  for (int i = 1; i < n; i++){
    cin >> d[i];
    edgesum += d[i];
  }
  //グラフ作る
  using P = pair<int, int>;
  vector<vector<P>> g(n);
  for (int i = 1; i < n; i++){
    g[i].emplace_back(p[i], d[i]);
    g[p[i]].emplace_back(i, d[i]);
  }
  //次数1撤去のグラフ作る ここでsum求める
  int sum = 0;
  vector<vector<P>> gg(n);
  for (int i = 0; i < n; i++){
    if (g[i].size() < 2) continue;
    for (var&& item : g[i]){
      if (g[item.first].size() < 2) continue;
      gg[i].push_back(item);
      sum += item.second;
    }
  }
  int diam = 0;
  //直径出す
  for (int start = 0; start < n; start++){
    if (gg[start].size() == 0) continue;
    vector<int> dist(n, -1);
    stack<int> st{};
    st.push(start);
    dist[start] = 0;
    while (!st.empty()){
      var elem = st.top(); st.pop();
      for (var&& item : gg[elem]){
        if (dist[item.first] != -1) continue;
        dist[item.first] = dist[elem] + item.second;
        st.push(item.first);
      }
    }
    var mx = accumulate(dist.begin(), dist.end(), -1, [](int a, int b){return max(a, b);});
    chmax(diam, mx);
  }
  cout << edgesum + sum - diam << endl;
  main();
}

