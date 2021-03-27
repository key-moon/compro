// detail: https://atcoder.jp/contests/utpc2020/submissions/21284691
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }


void solve() {
  int n, m;
  cin >> n >> m;
  
  ll suma = 0;
  vector<int> a(n);
  for (var&& elem : a) {
    cin >> elem;
    suma += elem;
  }
  sort(a.begin(), a.end());
  
  ll sumb = 0;
  priority_queue<int> pq;
  for (int i = 0; i < m; i++) {
    int b;
    cin >> b;
    sumb += b;
    pq.emplace(b);
  }

  if (suma < sumb) {
    cout << "No" << newl;
    return;
  }
  for (int i = n - 1; i >= 0; i--) {
    var item = a[i];

    while ((i != 0 && pq.size() == 1) || item < pq.top()) {
      var elem = pq.top(); pq.pop();
      pq.emplace(elem / 2);
      pq.emplace((elem + 1) / 2);
    }
    pq.pop();
  }

  cout << (pq.empty() ? "Yes" : "No") << newl;
}

int main() {
  ios::sync_with_stdio(false);
  cin.tie(nullptr);
  int t;
  cin >> t;
  for (int i = 0; i < t; i++) {
    solve();
  }
}
