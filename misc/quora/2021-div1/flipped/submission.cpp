#include <bits/stdc++.h>
#define var auto
using ll = long long;
const char newl = '\n';
template <typename T1, typename T2> inline void chmin(T1& a, T2 b) {if(a > b) a = b;}
template <typename T1, typename T2> inline void chmax(T1& a, T2 b) {if(a < b) a = b;}

using namespace std;

double get_log_likelihood(double mean, double vari, double x){
    return -(mean - x) * (mean - x) / vari;
}

double prob_of_flip = -1;

using DP = pair<double, double>;
using DPP = pair<DP, DP>;
DPP estimate(vector<double>& seq1, vector<double>& seq2){
  int n = seq1.size();
  int division = n;
  double gran = 1.0 / division;
  double avg1 = 0;
  double avg2 = 0;
  vector<int> cnts(division);
  for (int i = 0; i < n; i++){
    var ind1 = max((int)floor(seq1[i] / gran), division - 1);
    var ind2 = max((int)floor(seq2[i] / gran), division - 1);
    cnts[ind1]++;
    cnts[ind2]++;
    avg1 += seq1[i];
    avg2 += seq2[i];
  }
  avg1 /= n;
  avg2 /= n;
  var avg = (avg1 + avg2) / 2;
  var mean1 = (avg1 - avg * 2 * prob_of_flip) / (1 - prob_of_flip - prob_of_flip);
  var mean2 = avg * 2 - mean1;
  var var1 = 0.1;
  var var2 = 0.1;

  return DPP(DP(mean1, var1), DP(mean2, var2));
}

int main() {
  int n, b, f;
  cin >> n >> f >> b;
  prob_of_flip = ((double)b) / n;
  vector<vector<double>> mat(n, vector<double>(f));
  for (int i = 0; i < n; i++){
    for (int j = 0; j < f; j++){
      cin >> mat[i][j];
    }
  }
  vector<double> means(f);
  vector<double> vars(f);
  for (int i = 0; i < f; i++){
    var ind1 = i;
    var ind2 = f - i - 1;
    vector<double> seq1{};
    vector<double> seq2{};
    for (int j = 0; j < n; j++){
      seq1.emplace_back(mat[j][ind1]);
      seq2.emplace_back(mat[j][ind2]);
    }
    var [res1, res2] = estimate(seq1, seq2);
    var [mean1, var1] = res1;
    means[ind1] = mean1;
    vars[ind1] = var1;
    var [mean2, var2] = res2;
    means[ind2] = mean2;
    vars[ind2] = var2;
  }
  vector<pair<double, int>> likelihoods{};
  for (int i = 0; i < n; i++){
    double likelihood = 0; // likelihood of *not-flipped*
    for (int j = 0; j < f; j++){
      likelihood += get_log_likelihood(means[j], vars[j], mat[i][j]);
      likelihood -= get_log_likelihood(means[f - j - 1], vars[f - j - 1], mat[i][j]);
    }
    likelihoods.emplace_back(likelihood, i);
  }
  sort(likelihoods.begin(), likelihoods.end());
  for (int i = 0; i < b; i++){
    cout << likelihoods[i].second + 1 << endl;
  }
}
