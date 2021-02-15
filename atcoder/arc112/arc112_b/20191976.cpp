// detail: https://atcoder.jp/contests/arc112/submissions/20191976
#include <bits/stdc++.h>
#define var auto
using ll = long long;
const char newl = '\n';
template <typename T1, typename T2> inline void chmin(T1& a, T2 b) {if(a > b) a = b;}
template <typename T1, typename T2> inline void chmax(T1& a, T2 b) {if(a < b) a = b;}

using namespace std;

int main() {
  ll b, c;
  cin >> b >> c;
  using P = pair<ll, int>;
  vector<P> imos{};
  
  // 何もしない
  imos.emplace_back(b - c / 2, 1);
  imos.emplace_back(b + 1, -1);

  if (c >= 1){
    // 最初に -1
    imos.emplace_back(-b - (c - 1) / 2, 1);
    imos.emplace_back(-b + 1, -1);
  }

  if (c >= 1){
    // 最後に -1
    imos.emplace_back(-b, 1);
    imos.emplace_back(-b + (c - 1) / 2 + 1, -1);
  }

  if (c >= 2){
    // 両方
    imos.emplace_back(b, 1);
    imos.emplace_back(b + (c - 2) / 2 + 1, -1);
  }

  sort(imos.begin(), imos.end());
  ll res = 0;
  ll cur = 0;
  ll start = 0;
  for (auto&& [ind, d] : imos){
    if (cur == 0){
      start = ind;
    }
    cur += d;
    if (cur == 0){
      res += ind - start;
    }
  }
  cout << res << endl;
}
